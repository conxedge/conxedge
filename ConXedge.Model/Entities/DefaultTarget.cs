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
	/// IDefaultTarget interface for NHibernate mapped table 'DefaultTarget'.
	/// </summary>
	public interface IDefaultTarget
	{
		#region Public Properties
		
		string Targetid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
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
	/// DefaultTarget object for NHibernate mapped table 'DefaultTarget'.
	/// </summary>
	[Serializable]
	public class DefaultTarget : ICloneable,IDefaultTarget
	{
		#region Member Variables

		protected string _targetid;
		protected string _companyid;
		protected string _purpose;
		protected int _target;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public DefaultTarget() {}
		
		public DefaultTarget(string pTargetid, string pCompanyid, string pPurpose, int pTarget)
		{
			this._targetid = pTargetid; 
			this._companyid = pCompanyid; 
			this._purpose = pPurpose; 
			this._target = pTarget; 
		}
		
		public DefaultTarget(string pTargetid)
		{
			this._targetid = pTargetid; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Targetid
		{
			get { return _targetid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Targetid", "Targetid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_targetid != value); 
			  _targetid = value; 
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
			DefaultTarget castObj = null;
			try
			{
				castObj = (DefaultTarget)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._targetid == castObj.Targetid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _targetid.GetHashCode();
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
	
	#region Custom ICollection interface for DefaultTarget 

	
	public interface IDefaultTargetCollection : ICollection
	{
		DefaultTarget this[int index]{	get; set; }
		void Add(DefaultTarget pDefaultTarget);
		void Clear();
	}
	
	[Serializable]
	public class DefaultTargetCollection : IDefaultTargetCollection
	{
		private IList<DefaultTarget> _arrayInternal;

		public DefaultTargetCollection()
		{
			_arrayInternal = new List<DefaultTarget>();
		}
		
		public DefaultTargetCollection( IList<DefaultTarget> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<DefaultTarget>();
			}
		}

		public DefaultTarget this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((DefaultTarget[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(DefaultTarget pDefaultTarget) { _arrayInternal.Add(pDefaultTarget); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<DefaultTarget> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
