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
	/// IPour2Target interface for NHibernate mapped table 'Pour2Target'.
	/// </summary>
	public interface IPour2Target
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
		
		string Purpose
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
	/// Pour2Target object for NHibernate mapped table 'Pour2Target'.
	/// </summary>
	[Serializable]
	public class Pour2Target : ICloneable,IPour2Target
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _purpose;
		protected int _target;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public Pour2Target() {}
		
		public Pour2Target(string pId, string pPourid, string pPurpose, int pTarget)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._purpose = pPurpose; 
			this._target = pTarget; 
		}
		
		public Pour2Target(string pId)
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
		
		public string Purpose
		{
			get { return _purpose; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Purpose", "Purpose value, cannot contain more than 50 characters");
			  _bIsChanged |= (_purpose != value); 
			  _purpose = value; 
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
			Pour2Target castObj = null;
			try
			{
				castObj = (Pour2Target)obj;
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
	
	#region Custom ICollection interface for Pour2Target 

	
	public interface IPour2TargetCollection : ICollection
	{
		Pour2Target this[int index]{	get; set; }
		void Add(Pour2Target pPour2Target);
		void Clear();
	}
	
	[Serializable]
	public class Pour2TargetCollection : IPour2TargetCollection
	{
		private IList<Pour2Target> _arrayInternal;

		public Pour2TargetCollection()
		{
			_arrayInternal = new List<Pour2Target>();
		}
		
		public Pour2TargetCollection( IList<Pour2Target> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<Pour2Target>();
			}
		}

		public Pour2Target this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((Pour2Target[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(Pour2Target pPour2Target) { _arrayInternal.Add(pPour2Target); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<Pour2Target> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
