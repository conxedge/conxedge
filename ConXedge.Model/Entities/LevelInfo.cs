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
	/// ILevelInfo interface for NHibernate mapped table 'LevelInfo'.
	/// </summary>
	public interface ILevelInfo
	{
		#region Public Properties
		
		string Levelid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string LevelName
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// LevelInfo object for NHibernate mapped table 'LevelInfo'.
	/// </summary>
	[Serializable]
	public class LevelInfo : ICloneable,ILevelInfo
	{
		#region Member Variables

		protected string _levelid;
		protected string _companyid;
		protected string _levelname;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public LevelInfo() {}
		
		public LevelInfo(string pLevelid, string pCompanyid, string pLevelName)
		{
			this._levelid = pLevelid; 
			this._companyid = pCompanyid; 
			this._levelname = pLevelName; 
		}
		
		public LevelInfo(string pLevelid)
		{
			this._levelid = pLevelid; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Levelid
		{
			get { return _levelid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Levelid", "Levelid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_levelid != value); 
			  _levelid = value; 
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
		
		public string LevelName
		{
			get { return _levelname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("LevelName", "LevelName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_levelname != value); 
			  _levelname = value; 
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
			LevelInfo castObj = null;
			try
			{
				castObj = (LevelInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._levelid == castObj.Levelid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _levelid.GetHashCode();
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
	
	#region Custom ICollection interface for LevelInfo 

	
	public interface ILevelInfoCollection : ICollection
	{
		LevelInfo this[int index]{	get; set; }
		void Add(LevelInfo pLevelInfo);
		void Clear();
	}
	
	[Serializable]
	public class LevelInfoCollection : ILevelInfoCollection
	{
		private IList<LevelInfo> _arrayInternal;

		public LevelInfoCollection()
		{
			_arrayInternal = new List<LevelInfo>();
		}
		
		public LevelInfoCollection( IList<LevelInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<LevelInfo>();
			}
		}

		public LevelInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((LevelInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(LevelInfo pLevelInfo) { _arrayInternal.Add(pLevelInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<LevelInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
