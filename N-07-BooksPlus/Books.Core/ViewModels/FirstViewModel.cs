using System;
using System.Collections.Generic;
using System.Threading;
using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;

namespace Books.Core.ViewModels
{
	public class FirstViewModel 
		: MvxViewModel
	{
		private readonly object _lockObject = new object();
		private readonly IBooksService _books;
		private Timer _timer;

		public FirstViewModel(IBooksService books)
		{
			_books = books;
		}

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
		}
		
		private string _searchTerm;
		public string SearchTerm
		{
			get { return _searchTerm; }
			set
			{
			    if (_searchTerm == value)
			        return;
				_searchTerm = value; 
				RaisePropertyChanged(() => SearchTerm); 
				ScheduleUpdate();
			}
		}

		private void ScheduleUpdate()
		{
			lock (_lockObject)
			{
				if (_timer == null)
				{
					_timer = new Timer(OnTimerTick, null, TimeSpan.FromSeconds(1.0), TimeSpan.Zero);
				}
				else
				{
					_timer.Change(TimeSpan.FromSeconds(1.0), TimeSpan.Zero);
				}
			}
		}

		private List<BookSearchItem> _results;
		public List<BookSearchItem> Results
		{
			get { return _results; }
			set { _results = value; RaisePropertyChanged(() => Results); }
		}

		private void OnTimerTick(object state)
		{
			lock (_lockObject)
			{
				_timer.Dispose();
				_timer = null;
            }
            Update();
        }

		private void Update()
		{
			IsLoading = true;
			_books.StartSearchAsync(SearchTerm,
				result =>
					{
						IsLoading = false;
						Results = result.items;
					},
				error =>
					{
						IsLoading = false;
					});
		}        
	}
}
