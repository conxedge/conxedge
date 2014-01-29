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
	/// IVwLoggerInfo interface for NHibernate mapped table 'vwLoggerInfo'.
	/// </summary>
	public interface IVwLoggerInfo
	{
		#region Public Properties
		
		string Loggerid
		{
			get ;
		}
		
		string Companyid
		{
			get ;
		}
		
		string SerialNumber
		{
			get ;
		}
		
		string LoggerCode
		{
			get ;
		}
		
		string CurrentPourid
		{
			get ;
		}
		
		decimal? DataPointid
		{
			get ;
		}
		
		decimal? Eventid
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
	/// VwLoggerInfo object for NHibernate mapped table 'vwLoggerInfo'.
	/// </summary>
	[Serializable]
	public class VwLoggerInfo : ICloneable,IVwLoggerInfo
	{
		#region Member Variables

		protected string _loggerid;
		protected string _companyid;
		protected string _serialnumber;
		protected string _loggercode;
		protected string _currentpourid;
		protected decimal? _datapointid;
		protected decimal? _eventid;
		protected string _pourname;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwLoggerInfo() {}
		
		#endregion
		
		#region Public Properties
		
		public string Loggerid
		{
			get { return _loggerid; }
		}
		
		public string Companyid
		{
			get { return _companyid; }
		}
		
		public string SerialNumber
		{
			get { return _serialnumber; }
		}
		
		public string LoggerCode
		{
			get { return _loggercode; }
		}
		
		public string CurrentPourid
		{
			get { return _currentpourid; }
		}
		
		public decimal? DataPointid
		{
			get { return _datapointid; }
		}
		
		public decimal? Eventid
		{
			get { return _eventid; }
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
			VwLoggerInfo castObj = null;
			try
			{
				castObj = (VwLoggerInfo)obj;
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
	
	#region Custom ICollection interface for VwLoggerInfo 

	
	public interface IVwLoggerInfoCollection : ICollection
	{
		VwLoggerInfo this[int index]{	get; set; }
		void Add(VwLoggerInfo pVwLoggerInfo);
		void Clear();
	}
	
	[Serializable]
	public class VwLoggerInfoCollection : IVwLoggerInfoCollection
	{
		private IList<VwLoggerInfo> _arrayInternal;

		public VwLoggerInfoCollection()
		{
			_arrayInternal = new List<VwLoggerInfo>();
		}
		
		public VwLoggerInfoCollection( IList<VwLoggerInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwLoggerInfo>();
			}
		}

		public VwLoggerInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwLoggerInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwLoggerInfo pVwLoggerInfo) { _arrayInternal.Add(pVwLoggerInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwLoggerInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
