using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Uniframework.Services
{
    #region ServiceInfo
    /// <summary>
    /// ϵͳ������Ϣ��
    /// </summary>
    [Serializable]
    public class ServiceInfo
    {
        private string key;
        private string name;
        private string description;
        private ServiceType systemType;
        private ServiceScope serviceScope = ServiceScope.Global;
        private Type type;
        private List<RemoteMethodInfo> functions;

        /// <summary>
        /// �޲ι��캯��
        /// </summary>
        public ServiceInfo()
        {
            functions = new List<RemoteMethodInfo>();
        }

        /// <summary>
        /// ϵͳ������Ϣ�๹�췽��
        /// </summary>
        /// <param name="serviceKey">ϵͳ��ʶ</param>
        /// <param name="name">ϵͳ����</param>
        /// <param name="description">ϵͳ����</param>
        /// <param name="serviceType">ϵͳ����</param>
        /// <param name="type">���ͱ�ʶ</param>
        public ServiceInfo(string serviceKey, string name, string description, ServiceType serviceType, Type type)
            : this()
        {
            this.key = serviceKey;
            this.name = name;
            this.description = description;
            this.systemType = serviceType;
            this.type = type;
        }

        /// <summary>
        /// ���캯�������أ�
        /// </summary>
        /// <param name="serviceKey"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="serviceType"></param>
        /// <param name="type"></param>
        /// <param name="serviceScope"></param>
        public ServiceInfo(string serviceKey, string name, string description, ServiceType serviceType, Type type, ServiceScope serviceScope)
            : this(serviceKey, name, description, serviceType, type)
        {
            this.serviceScope = serviceScope;
        }

        /// <summary>
        /// ��ȡϵͳ��ʶ
        /// </summary>
        public string Key { get { return key; } }

        /// <summary>
        /// ��ȡϵͳ����
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// ��ȡϵͳ����
        /// </summary>
        public string Description 
        { 
            get { return description; }
        }

        /// <summary>
        /// ��ȡϵͳ����
        /// </summary>
        public ServiceType SystemType 
        { 
            get { return systemType; }
        }

        /// <summary>
        /// ���񷢲���Χ
        /// </summary>
        public ServiceScope ServiceScope
        {
            get { return serviceScope; }
        }

        /// <summary>
        /// ��ȡ���ͱ�ʶ
        /// </summary>
        public Type Type 
        { 
            get { return type; }
        }

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        public List<RemoteMethodInfo> Functions { get { return functions; } }

        /// <summary>
        /// ����ϵͳ����
        /// </summary>
        /// <param name="service">ϵͳ����</param>
        public void AddService(RemoteMethodInfo service)
        {
            functions.Add(service);
        }
    }
    #endregion

    #region RemoteMethodInfo

    /// <summary>
    /// ϵͳ����
    /// </summary>
    [Serializable]
    public class RemoteMethodInfo
    {
        private string key;
        private string serviceKey;
        private string name;
        private string description;
        private bool offline;
        private MethodInfo methodInfo;
        private string dataUpdateEvent;

        /// <summary>
        /// �޲ι��캯��
        /// </summary>
        public RemoteMethodInfo()
        { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="functionKey">������ʶ</param>
        /// <param name="serviceKey">��ϵͳ��ʶ</param>
        /// <param name="name">��������</param>
        /// <param name="description">��������</param>
        /// <param name="offline">�Ƿ�����߲���</param>
        /// <param name="methodInfo">MethodInfoʵ��</param>
        /// <param name="dataUpdateEvent">���ݸ����¼���</param>
        public RemoteMethodInfo(string functionKey, string serviceKey, string name, string description, bool offline, MethodInfo methodInfo, string dataUpdateEvent)
            : this()
        {
            this.key = functionKey;
            this.serviceKey = serviceKey;
            this.name = name;
            this.description = description;
            this.offline = offline;
            this.methodInfo = methodInfo;
            this.dataUpdateEvent = dataUpdateEvent;
        }

        #region RemoteMethodInfo Members

        /// <summary>
        /// ������ʶ
        /// </summary>
        public string Key { get { return key; } }

        /// <summary>
        /// ��ϵͳ��ʶ
        /// </summary>
        public string SubSystemKey { get { return serviceKey; } }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// ��������
        /// </summary>
        public string Description { get { return description; } }

        /// <summary>
        /// �Ƿ�����߲���
        /// </summary>
        public bool Offline { get { return offline; } }

        /// <summary>
        /// MethodInfoʵ��
        /// </summary>
        public MethodInfo MethodInfo { get { return methodInfo; } }

        /// <summary>
        /// ���ݸ����¼���
        /// </summary>
        public string DataUpdateEvent { get { return dataUpdateEvent; } }
        
        #endregion
    }

    #endregion

    #region ClientModuleInfo
    /// <summary>
    /// �ͻ���ģ����Ϣ
    /// </summary>
    [Serializable]
    public class ClientModuleInfo
    {
        private bool isMainModule = false;
        private string[] allowRoles;
        private string assemblyFile = string.Empty;
        private string updateLocation = string.Empty;

        /// <summary>
        /// �޲ι��캯��
        /// </summary>
        public ClientModuleInfo()
        { }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="allowRoles">���������Ľ�ɫ����</param>
        /// <param name="assemblyFile">�����ļ���</param>
        /// <param name="updateLocation">����λ��</param>
        /// <param name="isMainModule">�Ƿ���Ҫģ��</param>
        public ClientModuleInfo(string[] allowRoles, string assemblyFile, string updateLocation, bool isMainModule)
            : this()
        {
            this.allowRoles = allowRoles;
            this.assemblyFile = assemblyFile;
            this.updateLocation = updateLocation;
            this.isMainModule = isMainModule;
        }

        /// <summary>
        /// ��ȡ���������Ľ�ɫ����
        /// </summary>
        public string[] AllowedRoles { get { return allowRoles; } }

        /// <summary>
        /// ��ȡװ����ļ�
        /// </summary>
        public string AssemblyFile { get { return assemblyFile; } set { assemblyFile = value; } }

        /// <summary>
        /// ��ȡ����λ��
        /// </summary>
        public string UpdateLocation { get { return updateLocation; } }

        /// <summary>
        /// ��ȡ�Ƿ���Ҫģ��
        /// </summary>
        public bool IsMainModule { get { return isMainModule; } }
    }
    #endregion

    /// <summary>
    /// ���ٷ�����þ��ί��
    /// </summary>
    /// <param name="target">ί�е���Ŀ��</param>
    /// <param name="paramters">����</param>
    /// <returns></returns>
    public delegate object FastInvokeHandler(object target, object[] paramters);

    
    /// <summary>
    /// ϵͳ��������
    /// </summary>
    [RemoteService("ϵͳ��������", ServiceType.System)]
    public interface ISystemService
    {
        /// <summary>
        /// ��ϵͳ��ע��Ự
        /// </summary>
        /// <param name="sessionID">�Ự��ʶ</param>
        /// <param name="userName">�û�����</param>
        /// <param name="ipAddress">���÷�IP��ַ</param>
        /// <param name="encryptKey">��Կ</param>
        void RegisterSession(string sessionID, string userName, string ipAddress, string encryptKey);

        /// <summary>
        /// ���ָ�����͵ķ���
        /// </summary>
        /// <param name="type">��������</param>
        void InspectService(Type type);

        /// <summary>
        /// ע���Ự
        /// </summary>
        /// <param name="sessionID">�Ự��ʶ</param>
        [RemoteMethod("ע���Ự")]
        void UnRegisterSession(string sessionID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [RemoteMethod("��ȡ�ͻ���������Ϣ")]
        ClientModuleInfo[] GetClientModules();

        /// <summary>
        /// ��ȡԶ�̷���
        /// </summary>
        /// <returns>����ϵͳ���õ�����Զ�̷����б�</returns>
        List<ServiceInfo> GetAllServices();

        /// <summary>
        /// ��ȡԶ�̷���
        /// </summary>
        /// <param name="sessionID">�Ự��ʶ</param>
        /// <param name="clientType">�ͻ�������</param>
        /// <returns></returns>
        List<ServiceInfo> GetServices(string sessionID, ClientType clientType);

        /// <summary>
        /// ���ط���ԭ���Ա����
        /// </summary>
        /// <param name="methodInfo">��������</param>
        /// <returns></returns>
        FastInvokeHandler GetInvoker(MethodInfo methodInfo);
    }
}