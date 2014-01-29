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
	/// ICompanyInfo interface for NHibernate mapped table 'CompanyInfo'.
	/// </summary>
	public interface ICompanyInfo
	{
		#region Public Properties
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string CompanyName
		{
			get ;
			set ;
			  
		}
		
		string CompanyType
		{
			get ;
			set ;
			  
		}
		
		string Logo
		{
			get ;
			set ;
			  
		}
		
		string Style
		{
			get ;
			set ;
			  
		}
		
		string Remark
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// CompanyInfo object for NHibernate mapped table 'CompanyInfo'.
	/// </summary>
	[Serializable]
	public class CompanyInfo : ICloneable,ICompanyInfo
	{
		#region Member Variables

		protected string _companyid;
		protected string _companyname;
		protected string _companytype;
		protected string _logo;
		protected string _style;
		protected string _remark;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public CompanyInfo() {}
		
		public CompanyInfo(string pCompanyid, string pCompanyName, string pCompanyType, string pLogo, string pStyle, string pRemark)
		{
			this._companyid = pCompanyid; 
			this._companyname = pCompanyName; 
			this._companytype = pCompanyType; 
			this._logo = pLogo; 
			this._style = pStyle; 
			this._remark = pRemark; 
		}
		
		public CompanyInfo(string pCompanyid, string pCompanyName, string pCompanyType, string pLogo, string pStyle)
		{
			this._companyid = pCompanyid; 
			this._companyname = pCompanyName; 
			this._companytype = pCompanyType; 
			this._logo = pLogo; 
			this._style = pStyle; 
		}
		
		public CompanyInfo(string pCompanyid)
		{
			this._companyid = pCompanyid; 
		}
		
		#endregion
		
		#region Public Properties
		
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
		
		public string CompanyName
		{
			get { return _companyname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("CompanyName", "CompanyName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_companyname != value); 
			  _companyname = value; 
			}
			
		}
		
		public string CompanyType
		{
			get { return _companytype; }
			set 
			{
			  if (value != null && value.Length > 2)
			    throw new ArgumentOutOfRangeException("CompanyType", "CompanyType value, cannot contain more than 2 characters");
			  _bIsChanged |= (_companytype != value); 
			  _companytype = value; 
			}
			
		}
		
		public string Logo
		{
			get { return _logo; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Logo", "Logo value, cannot contain more than 50 characters");
			  _bIsChanged |= (_logo != value); 
			  _logo = value; 
			}
			
		}
		
		public string Style
		{
			get { return _style; }
			set 
			{
			  if (value != null && value.Length > 2)
			    throw new ArgumentOutOfRangeException("Style", "Style value, cannot contain more than 2 characters");
			  _bIsChanged |= (_style != value); 
			  _style = value; 
			}
			
		}
		
		public string Remark
		{
			get { return _remark; }
			set 
			{
			  if (value != null && value.Length > 500)
			    throw new ArgumentOutOfRangeException("Remark", "Remark value, cannot contain more than 500 characters");
			  _bIsChanged |= (_remark != value); 
			  _remark = value; 
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
			CompanyInfo castObj = null;
			try
			{
				castObj = (CompanyInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._companyid == castObj.Companyid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _companyid.GetHashCode();
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
	
	#region Custom ICollection interface for CompanyInfo 

	
	public interface ICompanyInfoCollection : ICollection
	{
		CompanyInfo this[int index]{	get; set; }
		void Add(CompanyInfo pCompanyInfo);
		void Clear();
	}
	
	[Serializable]
	public class CompanyInfoCollection : ICompanyInfoCollection
	{
		private IList<CompanyInfo> _arrayInternal;

		public CompanyInfoCollection()
		{
			_arrayInternal = new List<CompanyInfo>();
		}
		
		public CompanyInfoCollection( IList<CompanyInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<CompanyInfo>();
			}
		}

		public CompanyInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((CompanyInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(CompanyInfo pCompanyInfo) { _arrayInternal.Add(pCompanyInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<CompanyInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
