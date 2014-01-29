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
	/// IPourLocation interface for NHibernate mapped table 'PourLocation'.
	/// </summary>
	public interface IPourLocation
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
		
		string Locationid
		{
			get ;
			set ;
			  
		}
		
		string LocationDescription
		{
			get ;
			set ;
			  
		}
		
		string Details
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
		
		string MonitorType
		{
			get ;
			set ;
			  
		}
		
		DateTime? LogginStart
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourLocation object for NHibernate mapped table 'PourLocation'.
	/// </summary>
	[Serializable]
	public class PourLocation : ICloneable,IPourLocation
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _locationid;
		protected string _locationdescription;
		protected string _details;
		protected string _loggerid;
		protected int _channelno;
		protected string _monitortype;
		protected DateTime? _logginstart;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourLocation() {}
		
		public PourLocation(string pId, string pPourid, string pLocationid, string pLocationDescription, string pDetails, string pLoggerid, int pChannelNo, string pMonitorType, DateTime? pLogginStart)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._locationid = pLocationid; 
			this._locationdescription = pLocationDescription; 
			this._details = pDetails; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._monitortype = pMonitorType; 
			this._logginstart = pLogginStart; 
		}
		
		public PourLocation(string pId, string pPourid, string pLocationid, string pLocationDescription, string pLoggerid, int pChannelNo, string pMonitorType)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._locationid = pLocationid; 
			this._locationdescription = pLocationDescription; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._monitortype = pMonitorType; 
		}
		
		public PourLocation(string pId)
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
		
		public string Locationid
		{
			get { return _locationid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Locationid", "Locationid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_locationid != value); 
			  _locationid = value; 
			}
			
		}
		
		public string LocationDescription
		{
			get { return _locationdescription; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("LocationDescription", "LocationDescription value, cannot contain more than 50 characters");
			  _bIsChanged |= (_locationdescription != value); 
			  _locationdescription = value; 
			}
			
		}
		
		public string Details
		{
			get { return _details; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Details", "Details value, cannot contain more than 50 characters");
			  _bIsChanged |= (_details != value); 
			  _details = value; 
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
		
		public string MonitorType
		{
			get { return _monitortype; }
			set 
			{
			  if (value != null && value.Length > 1)
			    throw new ArgumentOutOfRangeException("MonitorType", "MonitorType value, cannot contain more than 1 characters");
			  _bIsChanged |= (_monitortype != value); 
			  _monitortype = value; 
			}
			
		}
		
		public DateTime? LogginStart
		{
			get { return _logginstart; }
			set { _bIsChanged |= (_logginstart != value); _logginstart = value; }
			
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
			PourLocation castObj = null;
			try
			{
				castObj = (PourLocation)obj;
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
	
	#region Custom ICollection interface for PourLocation 

	
	public interface IPourLocationCollection : ICollection
	{
		PourLocation this[int index]{	get; set; }
		void Add(PourLocation pPourLocation);
		void Clear();
	}
	
	[Serializable]
	public class PourLocationCollection : IPourLocationCollection
	{
		private IList<PourLocation> _arrayInternal;

		public PourLocationCollection()
		{
			_arrayInternal = new List<PourLocation>();
		}
		
		public PourLocationCollection( IList<PourLocation> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourLocation>();
			}
		}

		public PourLocation this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourLocation[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourLocation pPourLocation) { _arrayInternal.Add(pPourLocation); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourLocation> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
