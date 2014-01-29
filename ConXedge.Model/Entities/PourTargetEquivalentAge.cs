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
	/// IPourTargetEquivalentAge interface for NHibernate mapped table 'PourTargetEquivalentAge'.
	/// </summary>
	public interface IPourTargetEquivalentAge
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
		
		string Pour2Targetid
		{
			get ;
			set ;
			  
		}
		
		int Target
		{
			get ;
			set ;
			  
		}
		
		string CurrentTime
		{
			get ;
			set ;
			  
		}
		
		string Temp
		{
			get ;
			set ;
			  
		}
		
		string IsFinal
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourTargetEquivalentAge object for NHibernate mapped table 'PourTargetEquivalentAge'.
	/// </summary>
	[Serializable]
	public class PourTargetEquivalentAge : ICloneable,IPourTargetEquivalentAge
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _loggerid;
		protected int _channelno;
		protected string _pour2targetid;
		protected int _target;
		protected string _currenttime;
		protected string _temp;
		protected string _isfinal;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourTargetEquivalentAge() {}
		
		public PourTargetEquivalentAge(string pId, string pPourid, string pLoggerid, int pChannelNo, string pPour2Targetid, int pTarget, string pCurrentTime, string pTemp, string pIsFinal)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._loggerid = pLoggerid; 
			this._channelno = pChannelNo; 
			this._pour2targetid = pPour2Targetid; 
			this._target = pTarget; 
			this._currenttime = pCurrentTime; 
			this._temp = pTemp; 
			this._isfinal = pIsFinal; 
		}
		
		public PourTargetEquivalentAge(string pId)
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
		
		public string Pour2Targetid
		{
			get { return _pour2targetid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Pour2Targetid", "Pour2Targetid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_pour2targetid != value); 
			  _pour2targetid = value; 
			}
			
		}
		
		public int Target
		{
			get { return _target; }
			set { _bIsChanged |= (_target != value); _target = value; }
			
		}
		
		public string CurrentTime
		{
			get { return _currenttime; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("CurrentTime", "CurrentTime value, cannot contain more than 50 characters");
			  _bIsChanged |= (_currenttime != value); 
			  _currenttime = value; 
			}
			
		}
		
		public string Temp
		{
			get { return _temp; }
			set 
			{
			  if (value != null && value.Length > 10)
			    throw new ArgumentOutOfRangeException("Temp", "Temp value, cannot contain more than 10 characters");
			  _bIsChanged |= (_temp != value); 
			  _temp = value; 
			}
			
		}
		
		public string IsFinal
		{
			get { return _isfinal; }
			set 
			{
			  if (value != null && value.Length > 1)
			    throw new ArgumentOutOfRangeException("IsFinal", "IsFinal value, cannot contain more than 1 characters");
			  _bIsChanged |= (_isfinal != value); 
			  _isfinal = value; 
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
			PourTargetEquivalentAge castObj = null;
			try
			{
				castObj = (PourTargetEquivalentAge)obj;
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
	
	#region Custom ICollection interface for PourTargetEquivalentAge 

	
	public interface IPourTargetEquivalentAgeCollection : ICollection
	{
		PourTargetEquivalentAge this[int index]{	get; set; }
		void Add(PourTargetEquivalentAge pPourTargetEquivalentAge);
		void Clear();
	}
	
	[Serializable]
	public class PourTargetEquivalentAgeCollection : IPourTargetEquivalentAgeCollection
	{
		private IList<PourTargetEquivalentAge> _arrayInternal;

		public PourTargetEquivalentAgeCollection()
		{
			_arrayInternal = new List<PourTargetEquivalentAge>();
		}
		
		public PourTargetEquivalentAgeCollection( IList<PourTargetEquivalentAge> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourTargetEquivalentAge>();
			}
		}

		public PourTargetEquivalentAge this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourTargetEquivalentAge[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourTargetEquivalentAge pPourTargetEquivalentAge) { _arrayInternal.Add(pPourTargetEquivalentAge); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourTargetEquivalentAge> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
