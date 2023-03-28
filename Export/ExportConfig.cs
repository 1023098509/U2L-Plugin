using System.IO;
using System.Xml;
public class ExportConfig 
{
    private static string EditorConfig = "Assets/LayaAir3D/Configuration.xml";
    private static bool _updateConfig = false;
    //���� or Ԥ����
    private static int _FirstlevelMenu;
    //����δ����ڵ�
    private static bool _IgnoreNotActiveGameObject;
    //��������һ���ڵ�
    private static bool _BatchMade;
    //����uv
    private static bool _IgnoreVerticesUV;
    //����Normal
    private static bool _IgnoreVerticesNormal;
    //����tangent
    private static bool _IgnoreVerticesTangent;
    //����Color
    private static bool _IgnoreVerticesColor;
    //�Զ�����uv1
    private static bool _AutoVerticesUV1;
    //�Զ����Ŀ¼
    private static bool _CustomizeDirectory;
    //�Զ����Ŀ¼��
    private static string _CustomizeDirectoryName = "";

    //������ַ
    private static string _SAVEPATH = "Assets";

    //���� or Ԥ����
    public static int FirstlevelMenu
    {
        get { return _FirstlevelMenu; }
        set
        {
            if (_FirstlevelMenu != value)
            {
                _FirstlevelMenu = value;
                _updateConfig = true;
            }
        }
    }
    //����δ����ڵ�
    public static bool IgnoreNotActiveGameObject
    {
        get { return _IgnoreNotActiveGameObject; }
        set
        {
            if (_IgnoreNotActiveGameObject != value)
            {
                _IgnoreNotActiveGameObject = value;
                _updateConfig = true;
            }
        }
    }
    //��������һ���ڵ�
    public static bool BatchMade
    {
        get { return _BatchMade; }
        set
        {
            if (_BatchMade != value)
            {
                _BatchMade = value;
                _updateConfig = true;
            }
        }
    }
    //����uv
    public static bool IgnoreVerticesUV
    {
        get { return _IgnoreVerticesUV; }
        set
        {
            if (_IgnoreVerticesUV != value)
            {
                _IgnoreVerticesUV = value;
                _updateConfig = true;
            }
        }
    }
    //����Normal
    public static bool IgnoreVerticesNormal
    {
        get { return _IgnoreVerticesNormal; }
        set
        {
            if (_IgnoreVerticesNormal != value)
            {
                _IgnoreVerticesNormal = value;
                _updateConfig = true;
            }
        }
    }
    //����tangent
    public static bool IgnoreVerticesTangent
    {
        get { return _IgnoreVerticesTangent; }
        set
        {
            if (_IgnoreVerticesTangent != value)
            {
                _IgnoreVerticesTangent = value;
                _updateConfig = true;
            }
        }
    }
    //�Զ�����uv1
    public static bool AutoVerticesUV1
    {
        get { return _AutoVerticesUV1; }
        set
        {
            if (_AutoVerticesUV1 != value)
            {
                _AutoVerticesUV1 = value;
                _updateConfig = true;
            }
        }
    }
    
    //����Color
    public static bool IgnoreVerticesColor
    {
        get { return _IgnoreVerticesColor; }
        set
        {
            if (_IgnoreVerticesColor != value)
            {
                _IgnoreVerticesColor = value;
                _updateConfig = true;
            }
        }
    }
    //�Զ����Ŀ¼
    public static bool CustomizeDirectory
    {
        get { return _CustomizeDirectory; }
        set
        {
            if (_CustomizeDirectory != value)
            {
                _CustomizeDirectory = value;
                _updateConfig = true;
            }
        }
    }

    //�Զ����Ŀ¼��
    public static string CustomizeDirectoryName
    {
        get { return _CustomizeDirectoryName; }
        set
        {
            if (_CustomizeDirectoryName != value)
            {
                _CustomizeDirectoryName = value;
                _updateConfig = true;
            }
        }
    }

    //������ַ
    public static string SAVEPATH
    {
        get { return _SAVEPATH; }
        set
        {
            if (_SAVEPATH != value)
            {
                _SAVEPATH = value;
                _updateConfig = true;
            }
        }
    }


    public static string SavePath()
    {
        if (CustomizeDirectory)
        {
            return _SAVEPATH + "/" + CustomizeDirectoryName;
        }
        else
        {
            return _SAVEPATH;
        }
    }
    public static void initConfig()
    {
        if (_FirstlevelMenu != null)
        {
            return;
        }
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(EditorConfig);
        XmlNode xn = xmlDoc.SelectSingleNode("LayaExportSetting");
        FirstlevelMenu = int.Parse(xn.SelectSingleNode("FirstlevelMenu").InnerText);
        IgnoreNotActiveGameObject = bool.Parse(xn.SelectSingleNode("IgnoreNotActiveGameObject").InnerText);
        BatchMade = bool.Parse(xn.SelectSingleNode("BatchMade").InnerText);
        IgnoreVerticesUV = bool.Parse(xn.SelectSingleNode("IgnoreVerticesUV").InnerText);
        IgnoreVerticesNormal = bool.Parse(xn.SelectSingleNode("IgnoreVerticesNormal").InnerText);
        IgnoreVerticesTangent = bool.Parse(xn.SelectSingleNode("IgnoreVerticesTangent").InnerText);
        IgnoreVerticesColor = bool.Parse(xn.SelectSingleNode("IgnoreVerticesColor").InnerText);
        AutoVerticesUV1 = bool.Parse(xn.SelectSingleNode("AutoVerticesUV1").InnerText);
        CustomizeDirectory = bool.Parse(xn.SelectSingleNode("CustomizeDirectory").InnerText);
        CustomizeDirectoryName = xn.SelectSingleNode("CustomizeDirectoryName").InnerText;
        _SAVEPATH = xn.SelectSingleNode("SavePath").InnerText;
        _updateConfig = false;
    }
    public static void saveConfiguration()
    {
        if (!_updateConfig)
        {
            return;
        }
        _updateConfig = false;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(EditorConfig);
        XmlNode xn = xmlDoc.SelectSingleNode("LayaExportSetting");
        xn.SelectSingleNode("FirstlevelMenu").InnerText = FirstlevelMenu.ToString();
        xn.SelectSingleNode("IgnoreNotActiveGameObject").InnerText = IgnoreNotActiveGameObject.ToString();
        xn.SelectSingleNode("BatchMade").InnerText = BatchMade.ToString();
        xn.SelectSingleNode("IgnoreVerticesUV").InnerText = IgnoreVerticesUV.ToString();
        xn.SelectSingleNode("IgnoreVerticesNormal").InnerText = IgnoreVerticesNormal.ToString();
        xn.SelectSingleNode("IgnoreVerticesTangent").InnerText = IgnoreVerticesTangent.ToString();
        xn.SelectSingleNode("IgnoreVerticesColor").InnerText = IgnoreVerticesColor.ToString();
        xn.SelectSingleNode("AutoVerticesUV1").InnerText = AutoVerticesUV1.ToString();
        xn.SelectSingleNode("CustomizeDirectory").InnerText = CustomizeDirectory.ToString();
        xn.SelectSingleNode("CustomizeDirectoryName").InnerText = CustomizeDirectoryName;
        xn.SelectSingleNode("SavePath").InnerText = SAVEPATH;
        xmlDoc.Save(EditorConfig);
    }

    public static void ResetConfig()
    {
        FirstlevelMenu =0;
        IgnoreNotActiveGameObject = false;
        BatchMade = false;
        IgnoreVerticesUV = false;
        IgnoreVerticesNormal = false;
        IgnoreVerticesTangent = false;
        IgnoreVerticesColor = false;
        AutoVerticesUV1 = true;
        CustomizeDirectory = false;
        CustomizeDirectoryName ="";
        _SAVEPATH = "Assets";
    }
}
