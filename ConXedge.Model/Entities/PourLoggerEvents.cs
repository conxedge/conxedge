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
	/// IPourLoggerEvents interface for NHibernate mapped table 'PourLoggerEvents'.
	/// </summary>
	public interface IPourLoggerEvents
	{
		#region Public Properties
		
		string Id
		{
			get ;
			set ;
			  
		}
		
		string Pourid
		{
			get ;
			set ;
			  
		}
		
		decimal Eventid
		{
			get ;
			set ;
			  
		}
		
		int Flags
		{
			get ;
			set ;
			  
		}
		
		DateTime CurrentTime
		{
			get ;
			set ;
			  
		}
		
		int EventType
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
		
		decimal EventStartid
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourLoggerEvents object for NHibernate mapped table 'PourLoggerEvents'.
	/// </summary>
	[Serializable]
	public class PourLoggerEvents : ICloneable,IPourLoggerEvents
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected decimal _eventid;
		protected int _flags;
		protected DateTime _currenttime;
		protected int _eventtype;
		protected string _loggerid;
		protected int _channelno;
		protected decimal _eventstartid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourLoggerEvents() {}
		
		public PourLoggerEvents(string pId, string pPourid, decimal pEventid, int pFlags, DateTime pCurrentTime, int pEventType, string pLoggerid, int pChannelNo, decimal pEventStartid)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._eventid = pEventid; 
			this._flags = pFlags; 
			this._currenttime = pCurrentTime; 
			this._eventtype = pEventType; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._eventstartid = pEventStartid; 
		}
		
		public PourLoggerEvents(string pId)
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
		
		public string Pourid
		{
			get { return _pourid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Pourid", "Pourid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_pourid != value); 
			  _pourid = value; 
			}
			
		}
		
		public decimal Eventid
		{
			get { return _eventid; }
			set { _bIsChanged |= (_eventid != value); _eventid = value; }
			
		}
		
		public int Flags
		{
			get { return _flags; }
			set { _bIsChanged |= (_flags != value); _flags = value; }
			
		}
		
		public DateTime CurrentTime
		{
			get { return _currenttime; }
			set { _bIsChanged |= (_currenttime != value); _currenttime = value; }
			
		}
		
		public int EventType
		{
			get { return _eventtype; }
			set { _bIsChanged |= (_eventtype != value); _eventtype = value; }
			
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
		
		public decimal EventStartid
		{
			get { return _eventstartid; }
			set { _bIsChanged |= (_eventstartid != value); _eventstartid = value; }
			
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
			PourLoggerEvents castObj = null;
			try
			{
				castObj = (PourLoggerEvents)obj;
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
	
	#region Custom ICollection interface for PourLoggerEvents 

	
	public interface IPourLoggerEventsCollection : ICollection
	{
		PourLoggerEvents this[int index]{	get; set; }
		void Add(PourLoggerEvents pPourLoggerEvents);
		void Clear();
	}
	
	[Serializable]
	public class PourLoggerEventsCollection : IPourLoggerEventsCollection
	{
		private IList<PourLoggerEvents> _arrayInternal;

		public PourLoggerEventsCollection()
		{
			_arrayInternal = new List<PourLoggerEvents>();
		}
		
		public PourLoggerEventsCollection( IList<PourLoggerEvents> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourLoggerEvents>();
			}
		}

		public PourLoggerEvents this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourLoggerEvents[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourLoggerEvents pPourLoggerEvents) { _arrayInternal.Add(pPourLoggerEvents); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourLoggerEvents> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
