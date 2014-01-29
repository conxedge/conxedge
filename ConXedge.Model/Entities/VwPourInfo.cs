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
	/// IVwPourInfo interface for NHibernate mapped table 'vwPourInfo'.
	/// </summary>
	public interface IVwPourInfo
	{
		#region Public Properties
		
		string Contact
		{
			get ;
		}
		
		string Email
		{
			get ;
		}
		
		string ProjectName
		{
			get ;
		}
		
		string Supplier
		{
			get ;
		}
		
		string Code
		{
			get ;
		}
		
		string Description
		{
			get ;
		}
		
		string Pourid
		{
			get ;
		}
		
		string Projectid
		{
			get ;
		}
		
		string PourName
		{
			get ;
		}
		
		DateTime CreateDate
		{
			get ;
		}
		
		int PourVolume
		{
			get ;
		}
		
		string SetupBy
		{
			get ;
		}
		
		DateTime Started
		{
			get ;
		}
		
		DateTime Finished
		{
			get ;
		}
		
		string MaturityMethod
		{
			get ;
		}
		
		string Productid
		{
			get ;
		}
		
		string Contactid
		{
			get ;
		}
		
		string StopType
		{
			get ;
		}
		
		int Xhours
		{
			get ;
		}
		
		string Status
		{
			get ;
		}
		
		string PourType
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
	/// VwPourInfo object for NHibernate mapped table 'vwPourInfo'.
	/// </summary>
	[Serializable]
	public class VwPourInfo : ICloneable,IVwPourInfo
	{
		#region Member Variables

		protected string _contact;
		protected string _email;
		protected string _projectname;
		protected string _supplier;
		protected string _code;
		protected string _description;
		protected string _pourid;
		protected string _projectid;
		protected string _pourname;
		protected DateTime _createdate;
		protected int _pourvolume;
		protected string _setupby;
		protected DateTime _started;
		protected DateTime _finished;
		protected string _maturitymethod;
		protected string _productid;
		protected string _contactid;
		protected string _stoptype;
		protected int _xhours;
		protected string _status;
		protected string _pourtype;
		protected string _companyid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwPourInfo() {}
		
		#endregion
		
		#region Public Properties
		
		public string Contact
		{
			get { return _contact; }
		}
		
		public string Email
		{
			get { return _email; }
		}
		
		public string ProjectName
		{
			get { return _projectname; }
		}
		
		public string Supplier
		{
			get { return _supplier; }
		}
		
		public string Code
		{
			get { return _code; }
		}
		
		public string Description
		{
			get { return _description; }
		}
		
		public string Pourid
		{
			get { return _pourid; }
		}
		
		public string Projectid
		{
			get { return _projectid; }
		}
		
		public string PourName
		{
			get { return _pourname; }
		}
		
		public DateTime CreateDate
		{
			get { return _createdate; }
		}
		
		public int PourVolume
		{
			get { return _pourvolume; }
		}
		
		public string SetupBy
		{
			get { return _setupby; }
		}
		
		public DateTime Started
		{
			get { return _started; }
		}
		
		public DateTime Finished
		{
			get { return _finished; }
		}
		
		public string MaturityMethod
		{
			get { return _maturitymethod; }
		}
		
		public string Productid
		{
			get { return _productid; }
		}
		
		public string Contactid
		{
			get { return _contactid; }
		}
		
		public string StopType
		{
			get { return _stoptype; }
		}
		
		public int Xhours
		{
			get { return _xhours; }
		}
		
		public string Status
		{
			get { return _status; }
		}
		
		public string PourType
		{
			get { return _pourtype; }
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
			VwPourInfo castObj = null;
			try
			{
				castObj = (VwPourInfo)obj;
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
	
	#region Custom ICollection interface for VwPourInfo 

	
	public interface IVwPourInfoCollection : ICollection
	{
		VwPourInfo this[int index]{	get; set; }
		void Add(VwPourInfo pVwPourInfo);
		void Clear();
	}
	
	[Serializable]
	public class VwPourInfoCollection : IVwPourInfoCollection
	{
		private IList<VwPourInfo> _arrayInternal;

		public VwPourInfoCollection()
		{
			_arrayInternal = new List<VwPourInfo>();
		}
		
		public VwPourInfoCollection( IList<VwPourInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwPourInfo>();
			}
		}

		public VwPourInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwPourInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwPourInfo pVwPourInfo) { _arrayInternal.Add(pVwPourInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwPourInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
