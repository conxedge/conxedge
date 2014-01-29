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
	/// IPourInfo interface for NHibernate mapped table 'PourInfo'.
	/// </summary>
	public interface IPourInfo
	{
		#region Public Properties
		
		string Pourid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string Projectid
		{
			get ;
			set ;
			  
		}
		
		string PourName
		{
			get ;
			set ;
			  
		}
		
		DateTime CreateDate
		{
			get ;
			set ;
			  
		}
		
		int PourVolume
		{
			get ;
			set ;
			  
		}
		
		string PourType
		{
			get ;
			set ;
			  
		}
		
		string SetupBy
		{
			get ;
			set ;
			  
		}
		
		DateTime Started
		{
			get ;
			set ;
			  
		}
		
		DateTime Finished
		{
			get ;
			set ;
			  
		}
		
		string MaturityMethod
		{
			get ;
			set ;
			  
		}
		
		string Productid
		{
			get ;
			set ;
			  
		}
		
		string Contactid
		{
			get ;
			set ;
			  
		}
		
		string StopType
		{
			get ;
			set ;
			  
		}
		
		int Xhours
		{
			get ;
			set ;
			  
		}
		
		string Status
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// PourInfo object for NHibernate mapped table 'PourInfo'.
	/// </summary>
	[Serializable]
	public class PourInfo : ICloneable,IPourInfo
	{
		#region Member Variables

		protected string _pourid;
		protected string _companyid;
		protected string _projectid;
		protected string _pourname;
		protected DateTime _createdate;
		protected int _pourvolume;
		protected string _pourtype;
		protected string _setupby;
		protected DateTime _started;
		protected DateTime _finished;
		protected string _maturitymethod;
		protected string _productid;
		protected string _contactid;
		protected string _stoptype;
		protected int _xhours;
		protected string _status;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public PourInfo() {}
		
		public PourInfo(string pPourid, string pCompanyid, string pProjectid, string pPourName, DateTime pCreateDate, int pPourVolume, string pPourType, string pSetupBy, DateTime pStarted, DateTime pFinished, string pMaturityMethod, string pProductid, string pContactid, string pStopType, int pXhours, string pStatus)
		{
			this._pourid = pPourid; 
			this._companyid = pCompanyid; 
			this._projectid = pProjectid; 
			this._pourname = pPourName; 
			this._createdate = pCreateDate; 
			this._pourvolume = pPourVolume; 
			this._pourtype = pPourType; 
			this._setupby = pSetupBy; 
			this._started = pStarted; 
			this._finished = pFinished; 
			this._maturitymethod = pMaturityMethod; 
			this._productid = pProductid; 
			this._contactid = pContactid; 
			this._stoptype = pStopType; 
			this._xhours = pXhours; 
			this._status = pStatus; 
		}
		
		public PourInfo(string pPourid, string pCompanyid, string pPourName, DateTime pCreateDate, int pPourVolume, string pPourType, string pSetupBy, DateTime pStarted, DateTime pFinished, string pMaturityMethod, string pProductid, string pContactid, string pStopType, int pXhours, string pStatus)
		{
			this._pourid = pPourid; 
			this._companyid = pCompanyid; 
			this._pourname = pPourName; 
			this._createdate = pCreateDate; 
			this._pourvolume = pPourVolume; 
			this._pourtype = pPourType; 
			this._setupby = pSetupBy; 
			this._started = pStarted; 
			this._finished = pFinished; 
			this._maturitymethod = pMaturityMethod; 
			this._productid = pProductid; 
			this._contactid = pContactid; 
			this._stoptype = pStopType; 
			this._xhours = pXhours; 
			this._status = pStatus; 
		}
		
		public PourInfo(string pPourid)
		{
			this._pourid = pPourid; 
		}
		
		#endregion
		
		#region Public Properties
		
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
		
		public string Projectid
		{
			get { return _projectid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Projectid", "Projectid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_projectid != value); 
			  _projectid = value; 
			}
			
		}
		
		public string PourName
		{
			get { return _pourname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("PourName", "PourName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_pourname != value); 
			  _pourname = value; 
			}
			
		}
		
		public DateTime CreateDate
		{
			get { return _createdate; }
			set { _bIsChanged |= (_createdate != value); _createdate = value; }
			
		}
		
		public int PourVolume
		{
			get { return _pourvolume; }
			set { _bIsChanged |= (_pourvolume != value); _pourvolume = value; }
			
		}
		
		public string PourType
		{
			get { return _pourtype; }
			set 
			{
			  if (value != null && value.Length > 1)
			    throw new ArgumentOutOfRangeException("PourType", "PourType value, cannot contain more than 1 characters");
			  _bIsChanged |= (_pourtype != value); 
			  _pourtype = value; 
			}
			
		}
		
		public string SetupBy
		{
			get { return _setupby; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("SetupBy", "SetupBy value, cannot contain more than 50 characters");
			  _bIsChanged |= (_setupby != value); 
			  _setupby = value; 
			}
			
		}
		
		public DateTime Started
		{
			get { return _started; }
			set { _bIsChanged |= (_started != value); _started = value; }
			
		}
		
		public DateTime Finished
		{
			get { return _finished; }
			set { _bIsChanged |= (_finished != value); _finished = value; }
			
		}
		
		public string MaturityMethod
		{
			get { return _maturitymethod; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("MaturityMethod", "MaturityMethod value, cannot contain more than 50 characters");
			  _bIsChanged |= (_maturitymethod != value); 
			  _maturitymethod = value; 
			}
			
		}
		
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
		
		public string Contactid
		{
			get { return _contactid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Contactid", "Contactid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_contactid != value); 
			  _contactid = value; 
			}
			
		}
		
		public string StopType
		{
			get { return _stoptype; }
			set 
			{
			  if (value != null && value.Length > 2)
			    throw new ArgumentOutOfRangeException("StopType", "StopType value, cannot contain more than 2 characters");
			  _bIsChanged |= (_stoptype != value); 
			  _stoptype = value; 
			}
			
		}
		
		public int Xhours
		{
			get { return _xhours; }
			set { _bIsChanged |= (_xhours != value); _xhours = value; }
			
		}
		
		public string Status
		{
			get { return _status; }
			set 
			{
			  if (value != null && value.Length > 1)
			    throw new ArgumentOutOfRangeException("Status", "Status value, cannot contain more than 1 characters");
			  _bIsChanged |= (_status != value); 
			  _status = value; 
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
			PourInfo castObj = null;
			try
			{
				castObj = (PourInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._pourid == castObj.Pourid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _pourid.GetHashCode();
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
	
	#region Custom ICollection interface for PourInfo 

	
	public interface IPourInfoCollection : ICollection
	{
		PourInfo this[int index]{	get; set; }
		void Add(PourInfo pPourInfo);
		void Clear();
	}
	
	[Serializable]
	public class PourInfoCollection : IPourInfoCollection
	{
		private IList<PourInfo> _arrayInternal;

		public PourInfoCollection()
		{
			_arrayInternal = new List<PourInfo>();
		}
		
		public PourInfoCollection( IList<PourInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<PourInfo>();
			}
		}

		public PourInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((PourInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(PourInfo pPourInfo) { _arrayInternal.Add(pPourInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<PourInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
