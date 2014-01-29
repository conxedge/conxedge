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
	/// IVwProject2Logger interface for NHibernate mapped table 'vwProject2Logger'.
	/// </summary>
	public interface IVwProject2Logger
	{
		#region Public Properties
		
		string Id
		{
			get ;
		}
		
		string Projectid
		{
			get ;
		}
		
		string Loggerid
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
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// VwProject2Logger object for NHibernate mapped table 'vwProject2Logger'.
	/// </summary>
	[Serializable]
	public class VwProject2Logger : ICloneable,IVwProject2Logger
	{
		#region Member Variables

		protected string _id;
		protected string _projectid;
		protected string _loggerid;
		protected string _loggercode;
		protected string _companyid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwProject2Logger() {}
		
		#endregion
		
		#region Public Properties
		
		public string Id
		{
			get { return _id; }
		}
		
		public string Projectid
		{
			get { return _projectid; }
		}
		
		public string Loggerid
		{
			get { return _loggerid; }
		}
		
		public string LoggerCode
		{
			get { return _loggercode; }
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
			VwProject2Logger castObj = null;
			try
			{
				castObj = (VwProject2Logger)obj;
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
	
	#region Custom ICollection interface for VwProject2Logger 

	
	public interface IVwProject2LoggerCollection : ICollection
	{
		VwProject2Logger this[int index]{	get; set; }
		void Add(VwProject2Logger pVwProject2Logger);
		void Clear();
	}
	
	[Serializable]
	public class VwProject2LoggerCollection : IVwProject2LoggerCollection
	{
		private IList<VwProject2Logger> _arrayInternal;

		public VwProject2LoggerCollection()
		{
			_arrayInternal = new List<VwProject2Logger>();
		}
		
		public VwProject2LoggerCollection( IList<VwProject2Logger> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwProject2Logger>();
			}
		}

		public VwProject2Logger this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwProject2Logger[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwProject2Logger pVwProject2Logger) { _arrayInternal.Add(pVwProject2Logger); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwProject2Logger> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
