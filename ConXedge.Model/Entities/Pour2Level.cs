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
	/// IPour2Level interface for NHibernate mapped table 'Pour2Level'.
	/// </summary>
	public interface IPour2Level
	{
		#region Public Properties
		
		string Id
		{
			get ;
			set ;
			  
		}
		
		string Pourid
		{
			get ;
			set ;
			  
		}
		
		string Levelid
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// Pour2Level object for NHibernate mapped table 'Pour2Level'.
	/// </summary>
	[Serializable]
	public class Pour2Level : ICloneable,IPour2Level
	{
		#region Member Variables

		protected string _id;
		protected string _pourid;
		protected string _levelid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public Pour2Level() {}
		
		public Pour2Level(string pId, string pPourid, string pLevelid)
		{
			this._id = pId; 
			this._pourid = pPourid; 
			this._levelid = pLevelid; 
		}
		
		public Pour2Level(string pId, string pPourid)
		{
			this._id = pId; 
			this._pourid = pPourid; 
		}
		
		public Pour2Level(string pId)
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
		
		public string Levelid
		{
			get { return _levelid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Levelid", "Levelid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_levelid != value); 
			  _levelid = value; 
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
			Pour2Level castObj = null;
			try
			{
				castObj = (Pour2Level)obj;
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
	
	#region Custom ICollection interface for Pour2Level 

	
	public interface IPour2LevelCollection : ICollection
	{
		Pour2Level this[int index]{	get; set; }
		void Add(Pour2Level pPour2Level);
		void Clear();
	}
	
	[Serializable]
	public class Pour2LevelCollection : IPour2LevelCollection
	{
		private IList<Pour2Level> _arrayInternal;

		public Pour2LevelCollection()
		{
			_arrayInternal = new List<Pour2Level>();
		}
		
		public Pour2LevelCollection( IList<Pour2Level> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<Pour2Level>();
			}
		}

		public Pour2Level this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((Pour2Level[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(Pour2Level pPour2Level) { _arrayInternal.Add(pPour2Level); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<Pour2Level> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
