/*
using MyGeneration/Template/NHibernate (c) by Sharp 1.4
based on OHM (alvy77@hotmail.com)
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConXedge.Model
{

	/// <summary>
	/// ILog interface for NHibernate mapped table 'Log'.
	/// </summary>
	public interface ILog
	{
		#region Public Properties
		
		DateTime Date
		{
			get ;
			set ;
			  
		}
		
		string Thread
		{
			get ;
			set ;
			  
		}
		
		string Level
		{
			get ;
			set ;
			  
		}
		
		string Logger
		{
			get ;
			set ;
			  
		}
		
		string Message
		{
			get ;
			set ;
			  
		}
		
		string Exception
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// Log object for NHibernate mapped table 'Log'.
	/// </summary>
	[Serializable]
	public class Log : ICloneable,ILog
	{
		#region Member Variables

		protected DateTime _date;
		protected string _thread;
		protected string _level;
		protected string _logger;
		protected string _message;
		protected string _exception;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public Log() {}
		
		public Log(DateTime pDate, string pThread, string pLevel, string pLogger, string pMessage, string pException)
		{
			this._date = pDate; 
			this._thread = pThread; 
			this._level = pLevel; 
			this._logger = pLogger; 
			this._message = pMessage; 
			this._exception = pException; 
		}
		
		public Log(DateTime pDate)
		{
			this._date = pDate; 
		}
		
		#endregion
		
		#region Public Properties
		
		public DateTime Date
		{
			get { return _date; }
			set { _bIsChanged |= (_date != value); _date = value; }
			
		}
		
		public string Thread
		{
			get { return _thread; }
			set 
			{
			  if (value != null && value.Length > 255)
			    throw new ArgumentOutOfRangeException("Thread", "Thread value, cannot contain more than 255 characters");
			  _bIsChanged |= (_thread != value); 
			  _thread = value; 
			}
			
		}
		
		public string Level
		{
			get { return _level; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Level", "Level value, cannot contain more than 50 characters");
			  _bIsChanged |= (_level != value); 
			  _level = value; 
			}
			
		}
		
		public string Logger
		{
			get { return _logger; }
			set 
			{
			  if (value != null && value.Length > 255)
			    throw new ArgumentOutOfRangeException("Logger", "Logger value, cannot contain more than 255 characters");
			  _bIsChanged |= (_logger != value); 
			  _logger = value; 
			}
			
		}
		
		public string Message
		{
			get { return _message; }
			set 
			{
			  if (value != null && value.Length > 4000)
			    throw new ArgumentOutOfRangeException("Message", "Message value, cannot contain more than 4000 characters");
			  _bIsChanged |= (_message != value); 
			  _message = value; 
			}
			
		}
		
		public string Exception
		{
			get { return _exception; }
			set 
			{
			  if (value != null && value.Length > 2000)
			    throw new ArgumentOutOfRangeException("Exception", "Exception value, cannot contain more than 2000 characters");
			  _bIsChanged |= (_exception != value); 
			  _exception = value; 
			}
			
		}
		

		public bool IsDeleted
		{
			get
			{
				return _bIsDeleted;
			}
			set
			{
				_bIsDeleted = value;
			}
		}
		
		public bool IsChanged
		{
			get
			{
				return _bIsChanged;
			}
			set
			{
				_bIsChanged = value;
			}
		}
		
		#endregion 
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			Log castObj = null;
			try
			{
				castObj = (Log)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._date == castObj.Date );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _date.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region ICloneable methods
		
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	}
	
	#region Custom ICollection interface for Log 

	
	public interface ILogCollection : ICollection
	{
		Log this[int index]{	get; set; }
		void Add(Log pLog);
		void Clear();
	}
	
	[Serializable]
	public class LogCollection : ILogCollection
	{
		private IList<Log> _arrayInternal;

		public LogCollection()
		{
			_arrayInternal = new List<Log>();
		}
		
		public LogCollection( IList<Log> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<Log>();
			}
		}

		public Log this[int index]
		{
			get
			{
				return _arrayInternal[index];
			}
			set
			{
				_arrayInternal[index] = value;
			}
		}

		public int Count { get { return _arrayInternal.Count; } }
		public bool IsSynchronized { get { return false; } }
		public object SyncRoot { get { return _arrayInternal; } }
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((Log[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(Log pLog) { _arrayInternal.Add(pLog); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<Log> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
