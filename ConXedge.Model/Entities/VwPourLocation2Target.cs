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
	/// IVwPourLocation2Target interface for NHibernate mapped table 'vwPourLocation2Target'.
	/// </summary>
	public interface IVwPourLocation2Target
	{
		#region Public Properties
		
		string Id
		{
			get ;
		}
		
		string Pourid
		{
			get ;
		}
		
		string PourLocationid
		{
			get ;
		}
		
		string Pour2Targetid
		{
			get ;
		}
		
		int Target
		{
			get ;
		}
		
		string Locationid
		{
			get ;
		}
		
		string LocationDescription
		{
			get ;
		}
		
		string Details
		{
			get ;
		}
		
		string Loggerid
		{
			get ;
		}
		
		int? ChannelNo
		{
			get ;
		}
		
		string LoggerCode
		{
			get ;
		}
		
		string Purpose
		{
			get ;
		}
		
		int? DefaultTarget
		{
			get ;
		}
		
		string PourName
		{
			get ;
		}
		
		string Projectid
		{
			get ;
		}
		
		string Contactid
		{
			get ;
		}
		
		string ProjectName
		{
			get ;
		}
		
		string Contact
		{
			get ;
		}
		
		string Email
		{
			get ;
		}
		
		string MonitorType
		{
			get ;
		}
		
		DateTime? LogginStart
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
	/// VwPourLocation2Target object for NHibernate mapped table 'vwPourLocation2Target'.
	/// </summary>
	[Serializable]
	public class VwPourLocation2Target : ICloneable,IVwPourLocation2Target
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _pourlocationid;
		protected string _pour2targetid;
		protected int _target;
		protected string _locationid;
		protected string _locationdescription;
		protected string _details;
		protected string _loggerid;
		protected int? _channelno;
		protected string _loggercode;
		protected string _purpose;
		protected int? _defaulttarget;
		protected string _pourname;
		protected string _projectid;
		protected string _contactid;
		protected string _projectname;
		protected string _contact;
		protected string _email;
		protected string _monitortype;
		protected DateTime? _logginstart;
		protected string _companyid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwPourLocation2Target() {}
		
		#endregion
		
		#region Public Properties
		
		public string Id
		{
			get { return _id; }
		}
		
		public string Pourid
		{
			get { return _pourid; }
		}
		
		public string PourLocationid
		{
			get { return _pourlocationid; }
		}
		
		public string Pour2Targetid
		{
			get { return _pour2targetid; }
		}
		
		public int Target
		{
			get { return _target; }
		}
		
		public string Locationid
		{
			get { return _locationid; }
		}
		
		public string LocationDescription
		{
			get { return _locationdescription; }
		}
		
		public string Details
		{
			get { return _details; }
		}
		
		public string Loggerid
		{
			get { return _loggerid; }
		}
		
		public int? ChannelNo
		{
			get { return _channelno; }
		}
		
		public string LoggerCode
		{
			get { return _loggercode; }
		}
		
		public string Purpose
		{
			get { return _purpose; }
		}
		
		public int? DefaultTarget
		{
			get { return _defaulttarget; }
		}
		
		public string PourName
		{
			get { return _pourname; }
		}
		
		public string Projectid
		{
			get { return _projectid; }
		}
		
		public string Contactid
		{
			get { return _contactid; }
		}
		
		public string ProjectName
		{
			get { return _projectname; }
		}
		
		public string Contact
		{
			get { return _contact; }
		}
		
		public string Email
		{
			get { return _email; }
		}
		
		public string MonitorType
		{
			get { return _monitortype; }
		}
		
		public DateTime? LogginStart
		{
			get { return _logginstart; }
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
			VwPourLocation2Target castObj = null;
			try
			{
				castObj = (VwPourLocation2Target)obj;
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
	
	#region Custom ICollection interface for VwPourLocation2Target 

	
	public interface IVwPourLocation2TargetCollection : ICollection
	{
		VwPourLocation2Target this[int index]{	get; set; }
		void Add(VwPourLocation2Target pVwPourLocation2Target);
		void Clear();
	}
	
	[Serializable]
	public class VwPourLocation2TargetCollection : IVwPourLocation2TargetCollection
	{
		private IList<VwPourLocation2Target> _arrayInternal;

		public VwPourLocation2TargetCollection()
		{
			_arrayInternal = new List<VwPourLocation2Target>();
		}
		
		public VwPourLocation2TargetCollection( IList<VwPourLocation2Target> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwPourLocation2Target>();
			}
		}

		public VwPourLocation2Target this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwPourLocation2Target[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwPourLocation2Target pVwPourLocation2Target) { _arrayInternal.Add(pVwPourLocation2Target); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwPourLocation2Target> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
