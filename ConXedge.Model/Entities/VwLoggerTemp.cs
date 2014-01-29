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
	/// IVwLoggerTemp interface for NHibernate mapped table 'vwLoggerTemp'.
	/// </summary>
	public interface IVwLoggerTemp
	{
		#region Public Properties
		
		string Id
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
		
		DateTime CurrentTime
		{
			get ;
		}
		
		decimal Temp
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
		
		string PourName
		{
			get ;
		}
		
		string ProjectName
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
	/// VwLoggerTemp object for NHibernate mapped table 'vwLoggerTemp'.
	/// </summary>
	[Serializable]
	public class VwLoggerTemp : ICloneable,IVwLoggerTemp
	{
		#region Member Variables

		protected string _id;
		protected string _loggerid;
		protected int _channelno;
		protected DateTime _currenttime;
		protected decimal _temp;
		protected string _serialnumber;
		protected string _loggercode;
		protected string _currentpourid;
		protected string _pourname;
		protected string _projectname;
		protected string _companyid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwLoggerTemp() {}
		
		#endregion
		
		#region Public Properties
		
		public string Id
		{
			get { return _id; }
		}
		
		public string Loggerid
		{
			get { return _loggerid; }
		}
		
		public int ChannelNo
		{
			get { return _channelno; }
		}
		
		public DateTime CurrentTime
		{
			get { return _currenttime; }
		}
		
		public decimal Temp
		{
			get { return _temp; }
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
		
		public string PourName
		{
			get { return _pourname; }
		}
		
		public string ProjectName
		{
			get { return _projectname; }
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
			VwLoggerTemp castObj = null;
			try
			{
				castObj = (VwLoggerTemp)obj;
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
	
	#region Custom ICollection interface for VwLoggerTemp 

	
	public interface IVwLoggerTempCollection : ICollection
	{
		VwLoggerTemp this[int index]{	get; set; }
		void Add(VwLoggerTemp pVwLoggerTemp);
		void Clear();
	}
	
	[Serializable]
	public class VwLoggerTempCollection : IVwLoggerTempCollection
	{
		private IList<VwLoggerTemp> _arrayInternal;

		public VwLoggerTempCollection()
		{
			_arrayInternal = new List<VwLoggerTemp>();
		}
		
		public VwLoggerTempCollection( IList<VwLoggerTemp> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwLoggerTemp>();
			}
		}

		public VwLoggerTemp this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwLoggerTemp[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwLoggerTemp pVwLoggerTemp) { _arrayInternal.Add(pVwLoggerTemp); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwLoggerTemp> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
