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
	/// IContactInfo interface for NHibernate mapped table 'ContactInfo'.
	/// </summary>
	public interface IContactInfo
	{
		#region Public Properties
		
		string Contactid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string Contact
		{
			get ;
			set ;
			  
		}
		
		string Email
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// ContactInfo object for NHibernate mapped table 'ContactInfo'.
	/// </summary>
	[Serializable]
	public class ContactInfo : ICloneable,IContactInfo
	{
		#region Member Variables

		protected string _contactid;
		protected string _companyid;
		protected string _contact;
		protected string _email;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public ContactInfo() {}
		
		public ContactInfo(string pContactid, string pCompanyid, string pContact, string pEmail)
		{
			this._contactid = pContactid; 
			this._companyid = pCompanyid; 
			this._contact = pContact; 
			this._email = pEmail; 
		}
		
		public ContactInfo(string pContactid)
		{
			this._contactid = pContactid; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Contactid
		{
			get { return _contactid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Contactid", "Contactid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_contactid != value); 
			  _contactid = value; 
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
		
		public string Contact
		{
			get { return _contact; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Contact", "Contact value, cannot contain more than 50 characters");
			  _bIsChanged |= (_contact != value); 
			  _contact = value; 
			}
			
		}
		
		public string Email
		{
			get { return _email; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Email", "Email value, cannot contain more than 50 characters");
			  _bIsChanged |= (_email != value); 
			  _email = value; 
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
			ContactInfo castObj = null;
			try
			{
				castObj = (ContactInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._contactid == castObj.Contactid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _contactid.GetHashCode();
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
	
	#region Custom ICollection interface for ContactInfo 

	
	public interface IContactInfoCollection : ICollection
	{
		ContactInfo this[int index]{	get; set; }
		void Add(ContactInfo pContactInfo);
		void Clear();
	}
	
	[Serializable]
	public class ContactInfoCollection : IContactInfoCollection
	{
		private IList<ContactInfo> _arrayInternal;

		public ContactInfoCollection()
		{
			_arrayInternal = new List<ContactInfo>();
		}
		
		public ContactInfoCollection( IList<ContactInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<ContactInfo>();
			}
		}

		public ContactInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((ContactInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(ContactInfo pContactInfo) { _arrayInternal.Add(pContactInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<ContactInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
