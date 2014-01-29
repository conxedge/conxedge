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
	/// IPourLoggerTrack interface for NHibernate mapped table 'PourLoggerTrack'.
	/// </summary>
	public interface IPourLoggerTrack
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
		
		decimal DataPointid
		{
			get ;
			set ;
			  
		}
		
		DateTime CurrentTime
		{
			get ;
			set ;
			  
		}
		
		decimal Temp
		{
			get ;
			set ;
			  
		}
		
		decimal? EquivalentAge
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourLoggerTrack object for NHibernate mapped table 'PourLoggerTrack'.
	/// </summary>
	[Serializable]
	public class PourLoggerTrack : ICloneable,IPourLoggerTrack
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _loggerid;
		protected int _channelno;
		protected decimal _datapointid;
		protected DateTime _currenttime;
		protected decimal _temp;
		protected decimal? _equivalentage;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourLoggerTrack() {}
		
		public PourLoggerTrack(string pId, string pPourid, string pLoggerid, int pChannelNo, decimal pDataPointid, DateTime pCurrentTime, decimal pTemp, decimal? pEquivalentAge)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._datapointid = pDataPointid; 
			this._currenttime = pCurrentTime; 
			this._temp = pTemp; 
			this._equivalentage = pEquivalentAge; 
		}
		
		public PourLoggerTrack(string pId, string pPourid, string pLoggerid, int pChannelNo, decimal pDataPointid, DateTime pCurrentTime, decimal pTemp)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._datapointid = pDataPointid; 
			this._currenttime = pCurrentTime; 
			this._temp = pTemp; 
		}
		
		public PourLoggerTrack(string pId)
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
		
		public decimal DataPointid
		{
			get { return _datapointid; }
			set { _bIsChanged |= (_datapointid != value); _datapointid = value; }
			
		}
		
		public DateTime CurrentTime
		{
			get { return _currenttime; }
			set { _bIsChanged |= (_currenttime != value); _currenttime = value; }
			
		}
		
		public decimal Temp
		{
			get { return _temp; }
			set { _bIsChanged |= (_temp != value); _temp = value; }
			
		}
		
		public decimal? EquivalentAge
		{
			get { return _equivalentage; }
			set { _bIsChanged |= (_equivalentage != value); _equivalentage = value; }
			
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
			PourLoggerTrack castObj = null;
			try
			{
				castObj = (PourLoggerTrack)obj;
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
	
	#region Custom ICollection interface for PourLoggerTrack 

	
	public interface IPourLoggerTrackCollection : ICollection
	{
		PourLoggerTrack this[int index]{	get; set; }
		void Add(PourLoggerTrack pPourLoggerTrack);
		void Clear();
	}
	
	[Serializable]
	public class PourLoggerTrackCollection : IPourLoggerTrackCollection
	{
		private IList<PourLoggerTrack> _arrayInternal;

		public PourLoggerTrackCollection()
		{
			_arrayInternal = new List<PourLoggerTrack>();
		}
		
		public PourLoggerTrackCollection( IList<PourLoggerTrack> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourLoggerTrack>();
			}
		}

		public PourLoggerTrack this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourLoggerTrack[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourLoggerTrack pPourLoggerTrack) { _arrayInternal.Add(pPourLoggerTrack); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourLoggerTrack> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
