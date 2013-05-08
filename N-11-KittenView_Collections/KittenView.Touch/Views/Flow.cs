using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.CoreAnimation;

namespace KittenView.Touch
{
	public sealed class CardLayoutFlow   : UICollectionViewFlowLayout
	{
		private readonly UIView _superView;
		
		public CardLayoutFlow(UIView superView)
		{
			_superView = superView;
			ItemSize = new SizeF(100.0f, 153.0f);
			SectionInset = new UIEdgeInsets(0, 60, 0, 60);
			ScrollDirection = UICollectionViewScrollDirection.Horizontal;
		}
		
		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(RectangleF rect)
		{
			var layoutAttributes = base.LayoutAttributesForElementsInRect(rect);
			
			var modified = new List<UICollectionViewLayoutAttributes>();
			
			var horizontalCenter = CollectionView.Bounds.Width/2.0;
			foreach (var layout in layoutAttributes)
			{
				var originInCollectionView = new PointF(layout.Frame.Location.X, layout.Frame.Location.Y);
				var originInMainView = _superView.ConvertPointFromView(originInCollectionView, CollectionView);
				
				var centerInCollectionView = layout.Center; // new PointF(layout.c.Frame.Left + layout.Frame.Width/2,
				//layout.Frame.Top + layout.Frame.Height/2);
				var centerInMainView = _superView.ConvertPointFromView(centerInCollectionView, CollectionView);
				
				var rotateBy = 0.0f;
				var translateBy = PointF.Empty;
				
				// we find out where this cell is relative to the center of the viewport, and invoke private methods to deduce the
				// amount of rotation to apply
				if (originInMainView.X < CollectionView.Frame.Width + 80.0f)
				{
					translateBy = CalculateTranslateBy(horizontalCenter, layout);
					rotateBy = CalculateRotationFromViewPortDistance(originInMainView.X);
					
					var rotationPoint = new PointF(CollectionView.Frame.Width/2, CollectionView.Frame.Height);
					
					// there are two transforms and one rotation. this is needed to make the view appear to have rotated around
					// a certain point.
					
					CATransform3D transform = CATransform3D.Identity;
					transform = transform.Translate(rotationPoint.X - centerInMainView.X,
					                                rotationPoint.Y - centerInMainView.Y, 0.0f);
					transform = transform.Rotate(Maths.DegreesToRadians(-rotateBy), 0.0f, 0.0f, -1.0f);
					
					// -30.0f to lift the cards up a bit
					transform = transform.Translate(centerInMainView.X - rotationPoint.X,
					                                centerInMainView.Y - rotationPoint.Y - 30.0f, 0.0f);
					
					layout.Transform3D = transform;
					
					// right card is always on top
					layout.ZIndex = layout.IndexPath.Item;
					
					modified.Add(layout);
				}
			}
			return modified.ToArray();
		}
		
		PointF CalculateTranslateBy(double horizontalCenter, UICollectionViewLayoutAttributes  layout)
		{
			
			var translateByY = -layout.Frame.Height/2.0f;
			var distanceFromCenter = layout.Center.X - horizontalCenter;
			return new PointF((float)distanceFromCenter, translateByY);
		}
		
		
		float CalculateRotationFromViewPortDistance(float x)
		{
			float rotateByDegrees = RemapNumbersToRange(x, -122, 258, -35, 35);
			return rotateByDegrees;
		}
		
		float RemapNumbersToRange(float inputNumber, float fromMin, float fromMax, float toMin, float toMax)
		{
			return (inputNumber - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
		}
		
		/*
         http://stackoverflow.com/questions/13749401/stopping-the-scroll-in-a-uicollectionview
         */
		
		public override PointF TargetContentOffset(PointF proposedContentOffset, PointF scrollingVelocity)
		{
			var offsetAdjustment = float.MaxValue;
			var horizontalCenter = proposedContentOffset.X + CollectionView.Bounds.Width/1.4f;
			
			var targetRect = new RectangleF(proposedContentOffset.X,
			                                0.0f, CollectionView.Bounds.Width, CollectionView.Bounds.Height);
			
			var array = LayoutAttributesForElementsInRect(targetRect);
			foreach (var layout in array)
			{
				var distanceFromCenter = layout.Center.X - horizontalCenter;
				if (Math.Abs(distanceFromCenter) < Math.Abs(offsetAdjustment))
				{
					offsetAdjustment = distanceFromCenter;
				}
			}
			return new PointF(
				proposedContentOffset.X + offsetAdjustment,
				proposedContentOffset.Y);
		}
		
		public override bool ShouldInvalidateLayoutForBoundsChange(RectangleF newBounds)
		{
			return true;
		}
	}

	public static class Maths
	{
		public static float DegreesToRadians(float degrees)
		{
			return (float) ((degrees)/180.0*Math.PI);
		}
	}
}

