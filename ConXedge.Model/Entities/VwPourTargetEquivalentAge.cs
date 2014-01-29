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
	/// IVwPourTargetEquivalentAge interface for NHibernate mapped table 'vwPourTargetEquivalentAge'.
	/// </summary>
	public interface IVwPourTargetEquivalentAge
	{
		#region Public Properties
		
		string LoggerCode
		{
			get ;
		}
		
		string Id
		{
			get ;
		}
		
		string Pourid
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
		
		string Pour2Targetid
		{
			get ;
		}
		
		int Target
		{
			get ;
		}
		
		string CurrentTime
		{
			get ;
		}
		
		string Temp
		{
			get ;
		}
		
		string IsFinal
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
	/// VwPourTargetEquivalentAge object for NHibernate mapped table 'vwPourTargetEquivalentAge'.
	/// </summary>
	[Serializable]
	public class VwPourTargetEquivalentAge : ICloneable,IVwPourTargetEquivalentAge
	{
		#region Member Variables

		protected string _loggercode;
		protected string _id;
		protected string _pourid;
		protected string _loggerid;
		protected int _channelno;
		protected string _pour2targetid;
		protected int _target;
		protected string _currenttime;
		protected string _temp;
		protected string _isfinal;
		protected string _companyid;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public VwPourTargetEquivalentAge() {}
		
		#endregion
		
		#region Public Properties
		
		public string LoggerCode
		{
			get { return _loggercode; }
		}
		
		public string Id
		{
			get { return _id; }
		}
		
		public string Pourid
		{
			get { return _pourid; }
		}
		
		public string Loggerid
		{
			get { return _loggerid; }
		}
		
		public int ChannelNo
		{
			get { return _channelno; }
		}
		
		public string Pour2Targetid
		{
			get { return _pour2targetid; }
		}
		
		public int Target
		{
			get { return _target; }
		}
		
		public string CurrentTime
		{
			get { return _currenttime; }
		}
		
		public string Temp
		{
			get { return _temp; }
		}
		
		public string IsFinal
		{
			get { return _isfinal; }
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
			VwPourTargetEquivalentAge castObj = null;
			try
			{
				castObj = (VwPourTargetEquivalentAge)obj;
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
	
	#region Custom ICollection interface for VwPourTargetEquivalentAge 

	
	public interface IVwPourTargetEquivalentAgeCollection : ICollection
	{
		VwPourTargetEquivalentAge this[int index]{	get; set; }
		void Add(VwPourTargetEquivalentAge pVwPourTargetEquivalentAge);
		void Clear();
	}
	
	[Serializable]
	public class VwPourTargetEquivalentAgeCollection : IVwPourTargetEquivalentAgeCollection
	{
		private IList<VwPourTargetEquivalentAge> _arrayInternal;

		public VwPourTargetEquivalentAgeCollection()
		{
			_arrayInternal = new List<VwPourTargetEquivalentAge>();
		}
		
		public VwPourTargetEquivalentAgeCollection( IList<VwPourTargetEquivalentAge> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<VwPourTargetEquivalentAge>();
			}
		}

		public VwPourTargetEquivalentAge this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((VwPourTargetEquivalentAge[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(VwPourTargetEquivalentAge pVwPourTargetEquivalentAge) { _arrayInternal.Add(pVwPourTargetEquivalentAge); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<VwPourTargetEquivalentAge> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
