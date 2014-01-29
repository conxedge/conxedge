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
	/// IPourLocation2Target interface for NHibernate mapped table 'PourLocation2Target'.
	/// </summary>
	public interface IPourLocation2Target
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
		
		string PourLocationid
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
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourLocation2Target object for NHibernate mapped table 'PourLocation2Target'.
	/// </summary>
	[Serializable]
	public class PourLocation2Target : ICloneable,IPourLocation2Target
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _pourlocationid;
		protected string _pour2targetid;
		protected int _target;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourLocation2Target() {}
		
		public PourLocation2Target(string pId, string pPourid, string pPourLocationid, string pPour2Targetid, int pTarget)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._pourlocationid = pPourLocationid; 
			this._pour2targetid = pPour2Targetid; 
			this._target = pTarget; 
		}
		
		public PourLocation2Target(string pId)
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
		
		public string PourLocationid
		{
			get { return _pourlocationid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("PourLocationid", "PourLocationid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_pourlocationid != value); 
			  _pourlocationid = value; 
			}
			
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
			PourLocation2Target castObj = null;
			try
			{
				castObj = (PourLocation2Target)obj;
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
	
	#region Custom ICollection interface for PourLocation2Target 

	
	public interface IPourLocation2TargetCollection : ICollection
	{
		PourLocation2Target this[int index]{	get; set; }
		void Add(PourLocation2Target pPourLocation2Target);
		void Clear();
	}
	
	[Serializable]
	public class PourLocation2TargetCollection : IPourLocation2TargetCollection
	{
		private IList<PourLocation2Target> _arrayInternal;

		public PourLocation2TargetCollection()
		{
			_arrayInternal = new List<PourLocation2Target>();
		}
		
		public PourLocation2TargetCollection( IList<PourLocation2Target> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourLocation2Target>();
			}
		}

		public PourLocation2Target this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourLocation2Target[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourLocation2Target pPourLocation2Target) { _arrayInternal.Add(pPourLocation2Target); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourLocation2Target> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
