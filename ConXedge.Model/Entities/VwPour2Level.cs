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
	/// IVwPour2Level interface for NHibernate mapped table 'vwPour2Level'.
	/// </summary>
	public interface IVwPour2Level
	{
		#region Public Properties
		
		string LevelName
		{
			get ;
		}
		
		string Id
		{
			get ;
		}
		
		string Pourid
		{
			get ;
		}
		
		string Levelid
		{
			get ;
		}
		
		string Companyid
		{
			get ;
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// VwPour2Level object for NHibernate mapped table 'vwPour2Level'.
	/// </summary>
	[Serializable]
	public class VwPour2Level : ICloneable,IVwPour2Level
	{
		#region Member Variables

		protected string _levelname;
		protected string _id;
		protected string _pourid;
		protected string _levelid;
		protected string _companyid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwPour2Level() {}
		
		#endregion
		
		#region Public Properties
		
		public string LevelName
		{
			get { return _levelname; }
		}
		
		public string Id
		{
			get { return _id; }
		}
		
		public string Pourid
		{
			get { return _pourid; }
		}
		
		public string Levelid
		{
			get { return _levelid; }
		}
		
		public string Companyid
		{
			get { return _companyid; }
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
			VwPour2Level castObj = null;
			try
			{
				castObj = (VwPour2Level)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
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
	
	#region Custom ICollection interface for VwPour2Level 

	
	public interface IVwPour2LevelCollection : ICollection
	{
		VwPour2Level this[int index]{	get; set; }
		void Add(VwPour2Level pVwPour2Level);
		void Clear();
	}
	
	[Serializable]
	public class VwPour2LevelCollection : IVwPour2LevelCollection
	{
		private IList<VwPour2Level> _arrayInternal;

		public VwPour2LevelCollection()
		{
			_arrayInternal = new List<VwPour2Level>();
		}
		
		public VwPour2LevelCollection( IList<VwPour2Level> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwPour2Level>();
			}
		}

		public VwPour2Level this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwPour2Level[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwPour2Level pVwPour2Level) { _arrayInternal.Add(pVwPour2Level); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwPour2Level> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
