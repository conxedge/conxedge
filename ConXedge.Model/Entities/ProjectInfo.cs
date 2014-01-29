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
	/// IProjectInfo interface for NHibernate mapped table 'ProjectInfo'.
	/// </summary>
	public interface IProjectInfo
	{
		#region Public Properties
		
		string Projectid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string ProjectName
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// ProjectInfo object for NHibernate mapped table 'ProjectInfo'.
	/// </summary>
	[Serializable]
	public class ProjectInfo : ICloneable,IProjectInfo
	{
		#region Member Variables

		protected string _projectid;
		protected string _companyid;
		protected string _projectname;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public ProjectInfo() {}
		
		public ProjectInfo(string pProjectid, string pCompanyid, string pProjectName)
		{
			this._projectid = pProjectid; 
			this._companyid = pCompanyid; 
			this._projectname = pProjectName; 
		}
		
		public ProjectInfo(string pProjectid)
		{
			this._projectid = pProjectid; 
		}
		
		#endregion
		
		#region Public Properties
		
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
		
		public string ProjectName
		{
			get { return _projectname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("ProjectName", "ProjectName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_projectname != value); 
			  _projectname = value; 
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
			ProjectInfo castObj = null;
			try
			{
				castObj = (ProjectInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._projectid == castObj.Projectid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _projectid.GetHashCode();
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
	
	#region Custom ICollection interface for ProjectInfo 

	
	public interface IProjectInfoCollection : ICollection
	{
		ProjectInfo this[int index]{	get; set; }
		void Add(ProjectInfo pProjectInfo);
		void Clear();
	}
	
	[Serializable]
	public class ProjectInfoCollection : IProjectInfoCollection
	{
		private IList<ProjectInfo> _arrayInternal;

		public ProjectInfoCollection()
		{
			_arrayInternal = new List<ProjectInfo>();
		}
		
		public ProjectInfoCollection( IList<ProjectInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<ProjectInfo>();
			}
		}

		public ProjectInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((ProjectInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(ProjectInfo pProjectInfo) { _arrayInternal.Add(pProjectInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<ProjectInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
