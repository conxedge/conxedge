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
	/// ILoggerInfo interface for NHibernate mapped table 'LoggerInfo'.
	/// </summary>
	public interface ILoggerInfo
	{
		#region Public Properties
		
		string Loggerid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string SerialNumber
		{
			get ;
			set ;
			  
		}
		
		string LoggerCode
		{
			get ;
			set ;
			  
		}
		
		string CurrentPourid
		{
			get ;
			set ;
			  
		}
		
		decimal DataPointid
		{
			get ;
			set ;
			  
		}
		
		decimal Eventid
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// LoggerInfo object for NHibernate mapped table 'LoggerInfo'.
	/// </summary>
	[Serializable]
	public class LoggerInfo : ICloneable,ILoggerInfo
	{
		#region Member Variables

		protected string _loggerid;
		protected string _companyid;
		protected string _serialnumber;
		protected string _loggercode;
		protected string _currentpourid;
		protected decimal _datapointid;
		protected decimal _eventid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public LoggerInfo() {}
		
		public LoggerInfo(string pLoggerid, string pCompanyid, string pSerialNumber, string pLoggerCode, string pCurrentPourid, decimal pDataPointid, decimal pEventid)
		{
			this._loggerid = pLoggerid; 
			this._companyid = pCompanyid; 
			this._serialnumber = pSerialNumber; 
			this._loggercode = pLoggerCode; 
			this._currentpourid = pCurrentPourid; 
			this._datapointid = pDataPointid; 
			this._eventid = pEventid; 
		}
		
		public LoggerInfo(string pLoggerid, string pCompanyid, string pSerialNumber, string pLoggerCode)
		{
			this._loggerid = pLoggerid; 
			this._companyid = pCompanyid; 
			this._serialnumber = pSerialNumber; 
			this._loggercode = pLoggerCode; 
		}
		
		public LoggerInfo(string pLoggerid)
		{
			this._loggerid = pLoggerid; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Loggerid
		{
			get { return _loggerid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Loggerid", "Loggerid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_loggerid != value); 
			  _loggerid = value; 
			}
			
		}
		
		public string Companyid
		{
			get { return _companyid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Companyid", "Companyid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_companyid != value); 
			  _companyid = value; 
			}
			
		}
		
		public string SerialNumber
		{
			get { return _serialnumber; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("SerialNumber", "SerialNumber value, cannot contain more than 50 characters");
			  _bIsChanged |= (_serialnumber != value); 
			  _serialnumber = value; 
			}
			
		}
		
		public string LoggerCode
		{
			get { return _loggercode; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("LoggerCode", "LoggerCode value, cannot contain more than 50 characters");
			  _bIsChanged |= (_loggercode != value); 
			  _loggercode = value; 
			}
			
		}
		
		public string CurrentPourid
		{
			get { return _currentpourid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("CurrentPourid", "CurrentPourid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_currentpourid != value); 
			  _currentpourid = value; 
			}
			
		}
		
		public decimal DataPointid
		{
			get { return _datapointid; }
			set { _bIsChanged |= (_datapointid != value); _datapointid = value; }
			
		}
		
		public decimal Eventid
		{
			get { return _eventid; }
			set { _bIsChanged |= (_eventid != value); _eventid = value; }
			
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
			LoggerInfo castObj = null;
			try
			{
				castObj = (LoggerInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._loggerid == castObj.Loggerid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _loggerid.GetHashCode();
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
	
	#region Custom ICollection interface for LoggerInfo 

	
	public interface ILoggerInfoCollection : ICollection
	{
		LoggerInfo this[int index]{	get; set; }
		void Add(LoggerInfo pLoggerInfo);
		void Clear();
	}
	
	[Serializable]
	public class LoggerInfoCollection : ILoggerInfoCollection
	{
		private IList<LoggerInfo> _arrayInternal;

		public LoggerInfoCollection()
		{
			_arrayInternal = new List<LoggerInfo>();
		}
		
		public LoggerInfoCollection( IList<LoggerInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<LoggerInfo>();
			}
		}

		public LoggerInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((LoggerInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(LoggerInfo pLoggerInfo) { _arrayInternal.Add(pLoggerInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<LoggerInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
