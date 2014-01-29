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
	/// IParamInfo interface for NHibernate mapped table 'ParamInfo'.
	/// </summary>
	public interface IParamInfo
	{
		#region Public Properties
		
		string Id
		{
			get ;
			set ;
			  
		}
		
		string ParamName
		{
			get ;
			set ;
			  
		}
		
		decimal ParamValue
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// ParamInfo object for NHibernate mapped table 'ParamInfo'.
	/// </summary>
	[Serializable]
	public class ParamInfo : ICloneable,IParamInfo
	{
		#region Member Variables

		protected string _id;
		protected string _paramname;
		protected decimal _paramvalue;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public ParamInfo() {}
		
		public ParamInfo(string pId, string pParamName, decimal pParamValue)
		{
			this._id = pId; 
			this._paramname = pParamName; 
			this._paramvalue = pParamValue; 
		}
		
		public ParamInfo(string pId)
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
		
		public string ParamName
		{
			get { return _paramname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("ParamName", "ParamName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_paramname != value); 
			  _paramname = value; 
			}
			
		}
		
		public decimal ParamValue
		{
			get { return _paramvalue; }
			set { _bIsChanged |= (_paramvalue != value); _paramvalue = value; }
			
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
			ParamInfo castObj = null;
			try
			{
				castObj = (ParamInfo)obj;
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
	
	#region Custom ICollection interface for ParamInfo 

	
	public interface IParamInfoCollection : ICollection
	{
		ParamInfo this[int index]{	get; set; }
		void Add(ParamInfo pParamInfo);
		void Clear();
	}
	
	[Serializable]
	public class ParamInfoCollection : IParamInfoCollection
	{
		private IList<ParamInfo> _arrayInternal;

		public ParamInfoCollection()
		{
			_arrayInternal = new List<ParamInfo>();
		}
		
		public ParamInfoCollection( IList<ParamInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<ParamInfo>();
			}
		}

		public ParamInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((ParamInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(ParamInfo pParamInfo) { _arrayInternal.Add(pParamInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<ParamInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
