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
	/// IVwPourLocation interface for NHibernate mapped table 'vwPourLocation'.
	/// </summary>
	public interface IVwPourLocation
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
		
		int ChannelNo
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
		
		string LoggerCode
		{
			get ;
		}
		
		string Companyid
		{
			get ;
		}
		
		string Status
		{
			get ;
		}
		
		string PourName
		{
			get ;
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// VwPourLocation object for NHibernate mapped table 'vwPourLocation'.
	/// </summary>
	[Serializable]
	public class VwPourLocation : ICloneable,IVwPourLocation
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _locationid;
		protected string _locationdescription;
		protected string _details;
		protected string _loggerid;
		protected int _channelno;
		protected string _monitortype;
		protected DateTime? _logginstart;
		protected string _loggercode;
		protected string _companyid;
		protected string _status;
		protected string _pourname;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwPourLocation() {}
		
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
		
		public int ChannelNo
		{
			get { return _channelno; }
		}
		
		public string MonitorType
		{
			get { return _monitortype; }
		}
		
		public DateTime? LogginStart
		{
			get { return _logginstart; }
		}
		
		public string LoggerCode
		{
			get { return _loggercode; }
		}
		
		public string Companyid
		{
			get { return _companyid; }
		}
		
		public string Status
		{
			get { return _status; }
		}
		
		public string PourName
		{
			get { return _pourname; }
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
			VwPourLocation castObj = null;
			try
			{
				castObj = (VwPourLocation)obj;
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
	
	#region Custom ICollection interface for VwPourLocation 

	
	public interface IVwPourLocationCollection : ICollection
	{
		VwPourLocation this[int index]{	get; set; }
		void Add(VwPourLocation pVwPourLocation);
		void Clear();
	}
	
	[Serializable]
	public class VwPourLocationCollection : IVwPourLocationCollection
	{
		private IList<VwPourLocation> _arrayInternal;

		public VwPourLocationCollection()
		{
			_arrayInternal = new List<VwPourLocation>();
		}
		
		public VwPourLocationCollection( IList<VwPourLocation> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwPourLocation>();
			}
		}

		public VwPourLocation this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwPourLocation[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwPourLocation pVwPourLocation) { _arrayInternal.Add(pVwPourLocation); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwPourLocation> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
