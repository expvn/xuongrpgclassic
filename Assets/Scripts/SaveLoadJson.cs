using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadJson : MonoBehaviour
{
    [SerializeField] public List<User> users;
    // Start is called before the first frame update
    void Start()
    {
        users = new List<User>() 
        {
            new User { id = 1, name = "test1", password = "abc" },
            new User { id = 2, name = "test2", password = "def" },
            new User { id = 3, name = "test3", password = "ghi" },
        };
    }

    // Update is called once per frame
    void Update()
    {
        //save - bấm phím I để lưu dữ liệu
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Vì Json không convert trực tiếp list ra json nên phải đưa vào trong 1 đối tượng
            SaveUser saveUser = new SaveUser { users = users };
            //convert list sang chuỗi json
            string newJson = JsonUtility.ToJson(saveUser);
            //Lưu chuỗi vào key Account bằng PlayerPrefs
            PlayerPrefs.SetString("Account", newJson);
            print("Đã lưu dữ liệu user");
        }

        //load - bấm phím P để load dữ liệu và in ra
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Lấy chuỗi đã lưu bởi PlayerPrefs (lưu ý: phải gõ đúng key)
            string getJson = PlayerPrefs.GetString("Account");
            //Convert Json về đối tượng đã lưu
            SaveUser getSavedUsers = JsonUtility.FromJson<SaveUser>(getJson);
            List<User> savedUser = getSavedUsers.users;
            //in thử kết quả ra console
            foreach (User user in savedUser)
            {
                print($"ID: {user.id} - Name: {user.name} - Password: {user.password}");
            }
        }
    }
}

[System.Serializable]
public class User
{
    public int id;
    public string name;
    public string password;
}

[System.Serializable]
public class SaveUser
{
    public List<User> users;
}
