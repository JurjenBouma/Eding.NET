using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Web;
using System.IO;

namespace LANCNC
{
    public class UserFile
    {
        private List<User> m_userList;
        string m_fileName;

        public UserFile(string fileName)
        {
            m_userList = new List<User>();
            m_fileName = fileName;
            Load();
        }
        ~UserFile()
        {
            Save();
        }

        public void Save()
        {
            FileInfo fileInfo = new FileInfo(m_fileName);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            Stream stream = File.Open(m_fileName, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, m_userList);
            stream.Close();
        }

        public void Load()
        {
            if (File.Exists(m_fileName))
            {
                Stream stream = File.Open(m_fileName, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                m_userList = (List<User>)bFormatter.Deserialize(stream);
                stream.Close();
            }
        }

        public string[] GetUsers()
        {
            string[] items = new string[m_userList.Count];
            for (int i = 0; i < m_userList.Count; i++)
            {
                items[i] = m_userList[i].Name;
            }
            return items;
        }

        public User SignInUser(string userName)
        {
            User user = GetUser(userName);
            user.LastConnect = DateTime.Now;
            if (user.Name == "User not found")
            {
                user.Name = userName;
                user.AccessLevel = UserAccessLevel.None;
                if (m_userList.Count == 0)
                    user.AccessLevel = UserAccessLevel.Admin;
                AddUser(user);
                return user;
            }
            else
            {
                UpdateUserData(user);
                return user;
            }
        }

        public User GetUser(string userName)
        {
            foreach(User user in m_userList)
            {
                if(user.Name == userName)
                    return user;
            }
            return new User() { Name = "User not found"};
        }

        public void AddUser(User user)
        {
            m_userList.Add(user);
        }

        public void UpdateUserData(User user)
        {
            for(int i=0;i<m_userList.Count;i++)
            {
                if (m_userList[i].Name == user.Name)
                {
                    m_userList[i] = user;
                    break;
                }
            }
        }

        public void RemoveUser(string userName)
        {
            foreach (User user in m_userList)
            {
                if (user.Name == userName)
                {
                    m_userList.Remove(user);
                    break;
                }
            }
        }
    }

    [Serializable]
    public struct User
    {
        public string Name;
        public UserAccessLevel AccessLevel;
        public DateTime LastConnect;
    }

    public enum UserAccessLevel
    {
        None = 0,
        Watch = 1,
        Upload = 2,
        Control = 3,
        Admin = 4
    }
}