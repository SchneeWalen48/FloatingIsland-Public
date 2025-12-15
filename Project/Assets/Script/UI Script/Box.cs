using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Box : MonoBehaviour
{
    public ItemBuffer itemBuffer;
    public Transform slotRoot;//slot 오브젝트들
    [SerializeField]
    public static List<BoxSlot> boxSlots;

    public GameObject TreasureBoxs;

    [SerializeField]

    public System.Action<ItemProperty> onSlotClick;//deligate. 여기에 함수를 외부 내부에서 연결해 줄 수 있음, 그 조건이 반환형이 void고 파라미터가 딱 하나 있어야 함.

    void Update()
    {
        boxSlots = new List<BoxSlot>();
        
        int slotCount = slotRoot.childCount;
        
        if (GameObject.Find("T1").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(0).name)) 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.one.Count)
                {
                    boxSlot.SetItem(itemBuffer.one[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false; // HY : 여기서 false했기 때문에
                }

                boxSlots.Add(boxSlot);
            }

        }
        
        else if (GameObject.Find("T2").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(1).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.two.Count)
                {
                    boxSlot.SetItem(itemBuffer.two[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        else if (GameObject.Find("T3").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(2).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.three.Count)
                {
                    boxSlot.SetItem(itemBuffer.three[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        else if (GameObject.Find("T4").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(3).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.four.Count)
                {
                    boxSlot.SetItem(itemBuffer.four[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        else if (GameObject.Find("T5").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(4).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.five.Count)
                {
                    boxSlot.SetItem(itemBuffer.five[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        else if (GameObject.Find("T6").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(5).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.six.Count)
                {
                    boxSlot.SetItem(itemBuffer.six[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        else if (GameObject.Find("T7").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(6).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.seven.Count)
                {
                    boxSlot.SetItem(itemBuffer.seven[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T8").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(7).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.eight.Count)
                {
                    boxSlot.SetItem(itemBuffer.eight[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T9").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(8).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.nine.Count)
                {
                    boxSlot.SetItem(itemBuffer.nine[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
                
            }
        }

        else if (GameObject.Find("T10").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(9).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.ten.Count)
                {
                    boxSlot.SetItem(itemBuffer.ten[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T11").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(10).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.eleven.Count)
                {
                    boxSlot.SetItem(itemBuffer.eleven[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T12").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(11).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.twelve.Count)
                {
                    boxSlot.SetItem(itemBuffer.twelve[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T13").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(12).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.thirteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.thirteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T14").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(13).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.fourteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.fourteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T15").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(14).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.fifteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.fifteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_1").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(15).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_one.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_one[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_2").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(16).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_two.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_two[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_3").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(17).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_three.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_three[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_4").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(18).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_four.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_four[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_5").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(19).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_five.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_five[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T2_6").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(20).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_six.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_six[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_7").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(21).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_seven.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_seven[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T2_8").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(22).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_eight.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_eight[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_9").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(23).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_nine.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_nine[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T2_10").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(24).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_ten.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_ten[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_11").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(25).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_eleven.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_eleven[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T2_12").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(26).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_twelve.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_twelve[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T2_13").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(27).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_thirteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_thirteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        else if (GameObject.Find("T2_14").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(28).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_fourteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_fourteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_15").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(29).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_fifteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_fifteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_16").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(30).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_sixteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_sixteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_17").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(31).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_seventeen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_seventeen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_18").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(32).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_eighteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_eighteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T2_19").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(33).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.second_nineteen.Count)
                {
                    boxSlot.SetItem(itemBuffer.second_nineteen[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }
        
        // 2부 아이템 끝 
        else if (GameObject.Find("T3_1").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(34).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_one.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_one[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T3_2").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(35).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_two.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_two[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
                
            }
        }

        else if (GameObject.Find("T3_3").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(36).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_three.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_three[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T3_4").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(37).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_four.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_four[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T3_5").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(38).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_five.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_five[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T3_6").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(39).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_six.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_six[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T3_7").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(40).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_seven.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_seven[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

        else if (GameObject.Find("T3_8").GetComponent<TreasureBox>().boxName.Equals(TreasureBoxs.transform.GetChild(41).name))//메인카메라가 쏜 레이에 맞은 박스의 이름이 해당 박스의 이름과 일치하면, 아이템 버퍼의 리스트에 설정한 아이템들을 박스 슬롯에 넣음. 
        {
            for (int i = 0; i < slotCount; i++)
            {
                var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();

                if (i < itemBuffer.third_eight.Count)
                {
                    boxSlot.SetItem(itemBuffer.third_eight[i]);
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = true; // HY : 여기서 다시 true 해줘야 작동함
                }
                else
                {
                    boxSlot.image.enabled = false;
                    boxSlot.item = null;
                    boxSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                boxSlots.Add(boxSlot);
            }
        }

    }

    public void OnClickSlot(BoxSlot boxSlot)
    {
        if (onSlotClick != null)
        {
            onSlotClick(boxSlot.item);
        }
    }
    //상자 아이템 먹으면 상자 슬롯 아이템 사라지게, 근데 다른 아이템들 말고 책만 해당해야하므로 이프 아이템 타입 책인 경우로 하기
}
