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
	/// IProject2Logger interface for NHibernate mapped table 'Project2Logger'.
	/// </summary>
	public interface IProject2Logger
	{
		#region Public Properties
		
		string Id
		{
			get ;
			set ;
			  
		}
		
		string Projectid
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
	/// Project2Logger object for NHibernate mapped table 'Project2Logger'.
	/// </summary>
	[Serializable]
	public class Project2Logger : ICloneable,IProject2Logger
	{
		#region Member Variables

		protected string _id;
		protected string _projectid;
		protected string _loggerid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public Project2Logger() {}
		
		public Project2Logger(string pId, string pProjectid, string pLoggerid)
		{
			this._id = pId; 
			this._projectid = pProjectid; 
			this._loggerid = pLoggerid; 
		}
		
		public Project2Logger(string pId)
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
			Project2Logger castObj = null;
			try
			{
				castObj = (Project2Logger)obj;
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
	
	#region Custom ICollection interface for Project2Logger 

	
	public interface IProject2LoggerCollection : ICollection
	{
		Project2Logger this[int index]{	get; set; }
		void Add(Project2Logger pProject2Logger);
		void Clear();
	}
	
	[Serializable]
	public class Project2LoggerCollection : IProject2LoggerCollection
	{
		private IList<Project2Logger> _arrayInternal;

		public Project2LoggerCollection()
		{
			_arrayInternal = new List<Project2Logger>();
		}
		
		public Project2LoggerCollection( IList<Project2Logger> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<Project2Logger>();
			}
		}

		public Project2Logger this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((Project2Logger[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(Project2Logger pProject2Logger) { _arrayInternal.Add(pProject2Logger); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<Project2Logger> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
