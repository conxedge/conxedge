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
	/// IEquivalentAgeInfo interface for NHibernate mapped table 'EquivalentAgeInfo'.
	/// </summary>
	public interface IEquivalentAgeInfo
	{
		#region Public Properties
		
		string Id
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
		
		decimal EquivalentAge
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// EquivalentAgeInfo object for NHibernate mapped table 'EquivalentAgeInfo'.
	/// </summary>
	[Serializable]
	public class EquivalentAgeInfo : ICloneable,IEquivalentAgeInfo
	{
		#region Member Variables

		protected string _id;
		protected string _loggerid;
		protected int _channelno;
		protected DateTime _currenttime;
		protected decimal _equivalentage;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public EquivalentAgeInfo() {}
		
		public EquivalentAgeInfo(string pId, string pLoggerid, int pChannelNo, DateTime pCurrentTime, decimal pEquivalentAge)
		{
			this._id = pId; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._currenttime = pCurrentTime; 
			this._equivalentage = pEquivalentAge; 
		}
		
		public EquivalentAgeInfo(string pId)
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
		
		public decimal EquivalentAge
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
			EquivalentAgeInfo castObj = null;
			try
			{
				castObj = (EquivalentAgeInfo)obj;
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
	
	#region Custom ICollection interface for EquivalentAgeInfo 

	
	public interface IEquivalentAgeInfoCollection : ICollection
	{
		EquivalentAgeInfo this[int index]{	get; set; }
		void Add(EquivalentAgeInfo pEquivalentAgeInfo);
		void Clear();
	}
	
	[Serializable]
	public class EquivalentAgeInfoCollection : IEquivalentAgeInfoCollection
	{
		private IList<EquivalentAgeInfo> _arrayInternal;

		public EquivalentAgeInfoCollection()
		{
			_arrayInternal = new List<EquivalentAgeInfo>();
		}
		
		public EquivalentAgeInfoCollection( IList<EquivalentAgeInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<EquivalentAgeInfo>();
			}
		}

		public EquivalentAgeInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((EquivalentAgeInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(EquivalentAgeInfo pEquivalentAgeInfo) { _arrayInternal.Add(pEquivalentAgeInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<EquivalentAgeInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
