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
	/// IProductInfo interface for NHibernate mapped table 'ProductInfo'.
	/// </summary>
	public interface IProductInfo
	{
		#region Public Properties
		
		string Productid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string Supplier
		{
			get ;
			set ;
			  
		}
		
		string Code
		{
			get ;
			set ;
			  
		}
		
		string Description
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// ProductInfo object for NHibernate mapped table 'ProductInfo'.
	/// </summary>
	[Serializable]
	public class ProductInfo : ICloneable,IProductInfo
	{
		#region Member Variables

		protected string _productid;
		protected string _companyid;
		protected string _supplier;
		protected string _code;
		protected string _description;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public ProductInfo() {}
		
		public ProductInfo(string pProductid, string pCompanyid, string pSupplier, string pCode, string pDescription)
		{
			this._productid = pProductid; 
			this._companyid = pCompanyid; 
			this._supplier = pSupplier; 
			this._code = pCode; 
			this._description = pDescription; 
		}
		
		public ProductInfo(string pProductid)
		{
			this._productid = pProductid; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Productid
		{
			get { return _productid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Productid", "Productid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_productid != value); 
			  _productid = value; 
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
		
		public string Supplier
		{
			get { return _supplier; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Supplier", "Supplier value, cannot contain more than 50 characters");
			  _bIsChanged |= (_supplier != value); 
			  _supplier = value; 
			}
			
		}
		
		public string Code
		{
			get { return _code; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Code", "Code value, cannot contain more than 50 characters");
			  _bIsChanged |= (_code != value); 
			  _code = value; 
			}
			
		}
		
		public string Description
		{
			get { return _description; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Description", "Description value, cannot contain more than 50 characters");
			  _bIsChanged |= (_description != value); 
			  _description = value; 
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
			ProductInfo castObj = null;
			try
			{
				castObj = (ProductInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._productid == castObj.Productid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _productid.GetHashCode();
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
	
	#region Custom ICollection interface for ProductInfo 

	
	public interface IProductInfoCollection : ICollection
	{
		ProductInfo this[int index]{	get; set; }
		void Add(ProductInfo pProductInfo);
		void Clear();
	}
	
	[Serializable]
	public class ProductInfoCollection : IProductInfoCollection
	{
		private IList<ProductInfo> _arrayInternal;

		public ProductInfoCollection()
		{
			_arrayInternal = new List<ProductInfo>();
		}
		
		public ProductInfoCollection( IList<ProductInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<ProductInfo>();
			}
		}

		public ProductInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((ProductInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(ProductInfo pProductInfo) { _arrayInternal.Add(pProductInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<ProductInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
