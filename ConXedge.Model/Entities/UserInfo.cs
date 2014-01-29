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
	/// IUserInfo interface for NHibernate mapped table 'UserInfo'.
	/// </summary>
	public interface IUserInfo
	{
		#region Public Properties
		
		string Userid
		{
			get ;
			set ;
			  
		}
		
		string Companyid
		{
			get ;
			set ;
			  
		}
		
		string UserName
		{
			get ;
			set ;
			  
		}
		
		string Password
		{
			get ;
			set ;
			  
		}
		
		string UserType
		{
			get ;
			set ;
			  
		}
		
		string EmailAddress
		{
			get ;
			set ;
			  
		}
		
		string FirstName
		{
			get ;
			set ;
			  
		}
		
		string LastName
		{
			get ;
			set ;
			  
		}
		
		string JobTitle
		{
			get ;
			set ;
			  
		}
		
		string Mobile
		{
			get ;
			set ;
			  
		}
		
		string Phone
		{
			get ;
			set ;
			  
		}
		
		string Fax
		{
			get ;
			set ;
			  
		}
		
		bool IsDeleted { get; set; }
		bool IsChanged { get; set; }
		
		#endregion 
	}

	/// <summary>
	/// UserInfo object for NHibernate mapped table 'UserInfo'.
	/// </summary>
	[Serializable]
	public class UserInfo : ICloneable,IUserInfo
	{
		#region Member Variables

		protected string _userid;
		protected string _companyid;
		protected string _username;
		protected string _password;
		protected string _usertype;
		protected string _emailaddress;
		protected string _firstname;
		protected string _lastname;
		protected string _jobtitle;
		protected string _mobile;
		protected string _phone;
		protected string _fax;
		protected bool _bIsDeleted;
		protected bool _bIsChanged;
		#endregion
		
		#region Constructors
		public UserInfo() {}
		
		public UserInfo(string pUserid, string pCompanyid, string pUserName, string pPassword, string pUserType, string pEmailAddress, string pFirstName, string pLastName, string pJobTitle, string pMobile, string pPhone, string pFax)
		{
			this._userid = pUserid; 
			this._companyid = pCompanyid; 
			this._username = pUserName; 
			this._password = pPassword; 
			this._usertype = pUserType; 
			this._emailaddress = pEmailAddress; 
			this._firstname = pFirstName; 
			this._lastname = pLastName; 
			this._jobtitle = pJobTitle; 
			this._mobile = pMobile; 
			this._phone = pPhone; 
			this._fax = pFax; 
		}
		
		public UserInfo(string pUserid, string pCompanyid, string pUserName, string pPassword, string pUserType)
		{
			this._userid = pUserid; 
			this._companyid = pCompanyid; 
			this._username = pUserName; 
			this._password = pPassword; 
			this._usertype = pUserType; 
		}
		
		public UserInfo(string pUserid)
		{
			this._userid = pUserid; 
		}
		
		#endregion
		
		#region Public Properties
		
		public string Userid
		{
			get { return _userid; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Userid", "Userid value, cannot contain more than 50 characters");
			  _bIsChanged |= (_userid != value); 
			  _userid = value; 
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
		
		public string UserName
		{
			get { return _username; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("UserName", "UserName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_username != value); 
			  _username = value; 
			}
			
		}
		
		public string Password
		{
			get { return _password; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Password", "Password value, cannot contain more than 50 characters");
			  _bIsChanged |= (_password != value); 
			  _password = value; 
			}
			
		}
		
		public string UserType
		{
			get { return _usertype; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("UserType", "UserType value, cannot contain more than 50 characters");
			  _bIsChanged |= (_usertype != value); 
			  _usertype = value; 
			}
			
		}
		
		public string EmailAddress
		{
			get { return _emailaddress; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("EmailAddress", "EmailAddress value, cannot contain more than 50 characters");
			  _bIsChanged |= (_emailaddress != value); 
			  _emailaddress = value; 
			}
			
		}
		
		public string FirstName
		{
			get { return _firstname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("FirstName", "FirstName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_firstname != value); 
			  _firstname = value; 
			}
			
		}
		
		public string LastName
		{
			get { return _lastname; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("LastName", "LastName value, cannot contain more than 50 characters");
			  _bIsChanged |= (_lastname != value); 
			  _lastname = value; 
			}
			
		}
		
		public string JobTitle
		{
			get { return _jobtitle; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("JobTitle", "JobTitle value, cannot contain more than 50 characters");
			  _bIsChanged |= (_jobtitle != value); 
			  _jobtitle = value; 
			}
			
		}
		
		public string Mobile
		{
			get { return _mobile; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Mobile", "Mobile value, cannot contain more than 50 characters");
			  _bIsChanged |= (_mobile != value); 
			  _mobile = value; 
			}
			
		}
		
		public string Phone
		{
			get { return _phone; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Phone", "Phone value, cannot contain more than 50 characters");
			  _bIsChanged |= (_phone != value); 
			  _phone = value; 
			}
			
		}
		
		public string Fax
		{
			get { return _fax; }
			set 
			{
			  if (value != null && value.Length > 50)
			    throw new ArgumentOutOfRangeException("Fax", "Fax value, cannot contain more than 50 characters");
			  _bIsChanged |= (_fax != value); 
			  _fax = value; 
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
			UserInfo castObj = null;
			try
			{
				castObj = (UserInfo)obj;
			} catch(Exception) { return false; } 
			return ( castObj != null ) &&
				( this._userid == castObj.Userid );
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
		  
			
			int hash = 57; 
			hash = 27 * hash * _userid.GetHashCode();
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
	
	#region Custom ICollection interface for UserInfo 

	
	public interface IUserInfoCollection : ICollection
	{
		UserInfo this[int index]{	get; set; }
		void Add(UserInfo pUserInfo);
		void Clear();
	}
	
	[Serializable]
	public class UserInfoCollection : IUserInfoCollection
	{
		private IList<UserInfo> _arrayInternal;

		public UserInfoCollection()
		{
			_arrayInternal = new List<UserInfo>();
		}
		
		public UserInfoCollection( IList<UserInfo> pSource )
		{
			_arrayInternal = pSource;
			if(_arrayInternal == null)
			{
				_arrayInternal = new List<UserInfo>();
			}
		}

		public UserInfo this[int index]
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
		public void CopyTo(Array array, int index){ _arrayInternal.CopyTo((UserInfo[])array, index); }
		public IEnumerator GetEnumerator() { return _arrayInternal.GetEnumerator(); }
		public void Add(UserInfo pUserInfo) { _arrayInternal.Add(pUserInfo); }
		public void Clear() { _arrayInternal.Clear(); }
		public IList<UserInfo> GetList() { return _arrayInternal; }
	 }
	
	#endregion
}
