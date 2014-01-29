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
	/// IPourLoggerStatus interface for NHibernate mapped table 'PourLoggerStatus'.
	/// </summary>
	public interface IPourLoggerStatus
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
		
		decimal EquivalentAge
		{
			get ;
			set ;
			  
		}
		
		decimal Temp
		{
			get ;
			set ;
			  
		}
		
		string Status
		{
			get ;
			set ;
			  
		}
		
		DateTime? LoggingStarted
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourLoggerStatus object for NHibernate mapped table 'PourLoggerStatus'.
	/// </summary>
	[Serializable]
	public class PourLoggerStatus : ICloneable,IPourLoggerStatus
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _loggerid;
		protected int _channelno;
		protected decimal _equivalentage;
		protected decimal _temp;
		protected string _status;
		protected DateTime? _loggingstarted;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourLoggerStatus() {}
		
		public PourLoggerStatus(string pId, string pPourid, string pLoggerid, int pChannelNo, decimal pEquivalentAge, decimal pTemp, string pStatus, DateTime? pLoggingStarted)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._equivalentage = pEquivalentAge; 
			this._temp = pTemp; 
			this._status = pStatus; 
			this._loggingstarted = pLoggingStarted; 
		}
		
		public PourLoggerStatus(string pId, string pPourid, string pLoggerid, int pChannelNo, decimal pEquivalentAge, string pStatus)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._equivalentage = pEquivalentAge; 
			this._status = pStatus; 
		}
		
		public PourLoggerStatus(string pId)
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
		
		public decimal EquivalentAge
		{
			get { return _equivalentage; }
			set { _bIsChanged |= (_equivalentage != value); _equivalentage = value; }
			
		}
		
		public decimal Temp
		{
			get { return _temp; }
			set { _bIsChanged |= (_temp != value); _temp = value; }
			
		}
		
		public string Status
		{
			get { return _status; }
			set 
			{
			  if (value != null && value.Length > 1)
			    throw new ArgumentOutOfRangeException("Status", "Status value, cannot contain more than 1 characters");
			  _bIsChanged |= (_status != value); 
			  _status = value; 
			}
			
		}
		
		public DateTime? LoggingStarted
		{
			get { return _loggingstarted; }
			set { _bIsChanged |= (_loggingstarted != value); _loggingstarted = value; }
			
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
			PourLoggerStatus castObj = null;
			try
			{
				castObj = (PourLoggerStatus)obj;
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
	
	#region Custom ICollection interface for PourLoggerStatus 

	
	public interface IPourLoggerStatusCollection : ICollection
	{
		PourLoggerStatus this[int index]{	get; set; }
		void Add(PourLoggerStatus pPourLoggerStatus);
		void Clear();
	}
	
	[Serializable]
	public class PourLoggerStatusCollection : IPourLoggerStatusCollection
	{
		private IList<PourLoggerStatus> _arrayInternal;

		public PourLoggerStatusCollection()
		{
			_arrayInternal = new List<PourLoggerStatus>();
		}
		
		public PourLoggerStatusCollection( IList<PourLoggerStatus> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourLoggerStatus>();
			}
		}

		public PourLoggerStatus this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourLoggerStatus[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourLoggerStatus pPourLoggerStatus) { _arrayInternal.Add(pPourLoggerStatus); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourLoggerStatus> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
