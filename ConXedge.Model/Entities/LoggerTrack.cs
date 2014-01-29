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
	/// ILoggerTrack interface for NHibernate mapped table 'LoggerTrack'.
	/// </summary>
	public interface ILoggerTrack
	{
		#region Public Properties
		
		string Id
		{
			get ;
			set ;
			  
		}
		
		decimal DataPointid
		{
			get ;
			set ;
			  
		}
		
		string Loggerid
		{
			get ;
			set ;
			  
		}
		
		int ChannelNo
		{
			get ;
			set ;
			  
		}
		
		DateTime CurrentTime
		{
			get ;
			set ;
			  
		}
		
		int Flags
		{
			get ;
			set ;
			  
		}
		
		decimal Temp
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// LoggerTrack object for NHibernate mapped table 'LoggerTrack'.
	/// </summary>
	[Serializable]
	public class LoggerTrack : ICloneable,ILoggerTrack
	{
		#region Member Variables

		protected string _id;
		protected decimal _datapointid;
		protected string _loggerid;
		protected int _channelno;
		protected DateTime _currenttime;
		protected int _flags;
		protected decimal _temp;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public LoggerTrack() {}
		
		public LoggerTrack(string pId, decimal pDataPointid, string pLoggerid, int pChannelNo, DateTime pCurrentTime, int pFlags, decimal pTemp)
		{
			this._id = pId; 
			this._datapointid = pDataPointid; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._currenttime = pCurrentTime; 
			this._flags = pFlags; 
			this._temp = pTemp; 
		}
		
		public LoggerTrack(string pId)
		{
			this._id = pId; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Id
		{
			get { return _id; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Id", "Id value, cannot contain more than 50 characters");
			  _bIsChanged |= (_id != value); 
			  _id = value; 
			}
			
		}
		
		public decimal DataPointid
		{
			get { return _datapointid; }
			set { _bIsChanged |= (_datapointid != value); _datapointid = value; }
			
		}
		
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
		
		public int ChannelNo
		{
			get { return _channelno; }
			set { _bIsChanged |= (_channelno != value); _channelno = value; }
			
		}
		
		public DateTime CurrentTime
		{
			get { return _currenttime; }
			set { _bIsChanged |= (_currenttime != value); _currenttime = value; }
			
		}
		
		public int Flags
		{
			get { return _flags; }
			set { _bIsChanged |= (_flags != value); _flags = value; }
			
		}
		
		public decimal Temp
		{
			get { return _temp; }
			set { _bIsChanged |= (_temp != value); _temp = value; }
			
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
			LoggerTrack castObj = null;
			try
			{
				castObj = (LoggerTrack)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._id == castObj.Id );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _id.GetHashCode();
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
	
	#region Custom ICollection interface for LoggerTrack 

	
	public interface ILoggerTrackCollection : ICollection
	{
		LoggerTrack this[int index]{	get; set; }
		void Add(LoggerTrack pLoggerTrack);
		void Clear();
	}
	
	[Serializable]
	public class LoggerTrackCollection : ILoggerTrackCollection
	{
		private IList<LoggerTrack> _arrayInternal;

		public LoggerTrackCollection()
		{
			_arrayInternal = new List<LoggerTrack>();
		}
		
		public LoggerTrackCollection( IList<LoggerTrack> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<LoggerTrack>();
			}
		}

		public LoggerTrack this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((LoggerTrack[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(LoggerTrack pLoggerTrack) { _arrayInternal.Add(pLoggerTrack); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<LoggerTrack> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
