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
	/// ICompany2Logger interface for NHibernate mapped table 'Company2Logger'.
	/// </summary>
	public interface ICompany2Logger
	{
		#region Public Properties
		
		string Id
		{
			get ;
			set ;
			  
		}
		
		string CurrentCompanyid
		{
			get ;
			set ;
			  
		}
		
		string Loggerid
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// Company2Logger object for NHibernate mapped table 'Company2Logger'.
	/// </summary>
	[Serializable]
	public class Company2Logger : ICloneable,ICompany2Logger
	{
		#region Member Variables

		protected string _id;
		protected string _currentcompanyid;
		protected string _loggerid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public Company2Logger() {}
		
		public Company2Logger(string pId, string pCurrentCompanyid, string pLoggerid)
		{
			this._id = pId; 
			this._currentcompanyid = pCurrentCompanyid; 
			this._loggerid = pLoggerid; 
		}
		
		public Company2Logger(string pId)
		{
			this._id = pId; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Id
		{
			get { return _id; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Id", "Id value, cannot contain more than 50 characters");
			  _bIsChanged |= (_id != value); 
			  _id = value; 
			}
			
		}
		
		public string CurrentCompanyid
		{
			get { return _currentcompanyid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("CurrentCompanyid", "CurrentCompanyid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_currentcompanyid != value); 
			  _currentcompanyid = value; 
			}
			
		}
		
		public string Loggerid
		{
			get { return _loggerid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Loggerid", "Loggerid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_loggerid != value); 
			  _loggerid = value; 
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
			Company2Logger castObj = null;
			try
			{
				castObj = (Company2Logger)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._id == castObj.Id );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _id.GetHashCode();
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
	
	#region Custom ICollection interface for Company2Logger 

	
	public interface ICompany2LoggerCollection : ICollection
	{
		Company2Logger this[int index]{	get; set; }
		void Add(Company2Logger pCompany2Logger);
		void Clear();
	}
	
	[Serializable]
	public class Company2LoggerCollection : ICompany2LoggerCollection
	{
		private IList<Company2Logger> _arrayInternal;

		public Company2LoggerCollection()
		{
			_arrayInternal = new List<Company2Logger>();
		}
		
		public Company2LoggerCollection( IList<Company2Logger> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<Company2Logger>();
			}
		}

		public Company2Logger this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((Company2Logger[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(Company2Logger pCompany2Logger) { _arrayInternal.Add(pCompany2Logger); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<Company2Logger> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
