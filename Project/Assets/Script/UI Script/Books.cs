using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    public AudioSource paper;
    public GameObject BookInven;
    public GameObject CloseBtn;
    public GameObject BoxInven;
    public GameObject Inven;
    public GameObject BookUIButton;

    public GameObject RightBtn_two_1;
    public GameObject LeftBtn_two_1;
    public GameObject RightBtn_two_2;
    public GameObject LeftBtn_two_2;
    public GameObject RightBtn_six;
    public GameObject LeftBtn_six;
    public GameObject RightBtn_eight;
    public GameObject LeftBtn_eight;
    public GameObject RightBtn_nine_1;
    public GameObject RightBtn_nine_2;
    public GameObject RightBtn_nine_3;
    public GameObject LeftBtn_nine_1;
    public GameObject LeftBtn_nine_2;
    public GameObject LeftBtn_nine_3;
    public GameObject RightBtn_ten;
    public GameObject LeftBtn_ten;
    public GameObject RightBtn_eleven;
    public GameObject LeftBtn_eleven;
    public GameObject RightBtn_twelve;
    public GameObject LeftBtn_twelve;
    public GameObject RightBtn_thirteen;
    public GameObject LeftBtn_thirteen;




    public GameObject book1;
    public GameObject book2_1;
    public GameObject book2_2;
    public GameObject book2_3;
    public GameObject book3;
    public GameObject book4;
    public GameObject book5;
    public GameObject book6_1;
    public GameObject book6_2;
    public GameObject book7;
    public GameObject book8_1;
    public GameObject book8_2;
    public GameObject book9_1;
    public GameObject book9_2;
    public GameObject book9_3;
    public GameObject book9_4;
    public GameObject book10_1;
    public GameObject book10_2;
    public GameObject book11_1;
    public GameObject book11_2;
    public GameObject book12_1;
    public GameObject book12_2;
    public GameObject book13_1;
    public GameObject book13_2;
    public GameObject book14;



    public void CloseBook()
    {
        CloseBtn.gameObject.SetActive(false);
        BookUIButton.gameObject.SetActive(true);
        book1.gameObject.SetActive(false);
        book2_1.gameObject.SetActive(false);
        book2_2.gameObject.SetActive(false);
        book2_3.gameObject.SetActive(false);
        book3.gameObject.SetActive(false);
        book4.gameObject.SetActive(false);
        book5.gameObject.SetActive(false);
        book6_1.gameObject.SetActive(false);
        book6_2.gameObject.SetActive(false);
        book7.gameObject.SetActive(false);
        book8_1.gameObject.SetActive(false);
        book8_2.gameObject.SetActive(false);
        book9_1.gameObject.SetActive(false);
        book9_2.gameObject.SetActive(false);
        book9_3.gameObject.SetActive(false);
        book9_4.gameObject.SetActive(false);
        book10_1.gameObject.SetActive(false);
        book10_2.gameObject.SetActive(false);
        book11_1.gameObject.SetActive(false);
        book11_2.gameObject.SetActive(false);
        book12_1.gameObject.SetActive(false);
        book12_2.gameObject.SetActive(false);
        book13_1.gameObject.SetActive(false);
        book13_2.gameObject.SetActive(false);
        book14.gameObject.SetActive(false);

        RightBtn_two_1.gameObject.SetActive(false);
        RightBtn_two_2.gameObject.SetActive(false);

        LeftBtn_two_1.gameObject.SetActive(false);
        LeftBtn_two_2.gameObject.SetActive(false);

        RightBtn_nine_1.gameObject.SetActive(false);
        RightBtn_nine_2.gameObject.SetActive(false);
        RightBtn_nine_3.gameObject.SetActive(false);

        LeftBtn_nine_1.gameObject.SetActive(false);
        LeftBtn_nine_2.gameObject.SetActive(false);
        LeftBtn_nine_3.gameObject.SetActive(false);

        RightBtn_six.gameObject.SetActive(false);
        LeftBtn_six.gameObject.SetActive(false);

        RightBtn_eight.gameObject.SetActive(false);
        LeftBtn_eight.gameObject.SetActive(false);

        RightBtn_ten.gameObject.SetActive(false);
        LeftBtn_ten.gameObject.SetActive(false);

        RightBtn_eleven.gameObject.SetActive(false);
        LeftBtn_eleven.gameObject.SetActive(false);

        RightBtn_twelve.gameObject.SetActive(false);
        LeftBtn_twelve.gameObject.SetActive(false);

        RightBtn_thirteen.gameObject.SetActive(false);
        LeftBtn_thirteen.gameObject.SetActive(false);



    }

    public void Right_btn_two_1()
    {
        book2_1.gameObject.SetActive(false);
        book2_2.gameObject.SetActive(true);
        RightBtn_two_1.gameObject.SetActive(false);
        RightBtn_two_2.gameObject.SetActive(true);
        LeftBtn_two_1.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_two_1()
    {
        book2_1.gameObject.SetActive(true);
        book2_2.gameObject.SetActive(false);
        RightBtn_two_1.gameObject.SetActive(true);
        RightBtn_two_2.gameObject.SetActive(false);
        LeftBtn_two_1.gameObject.SetActive(false);
        paper.Play();
    }

    public void Right_btn_two_2()
    {
        book2_3.gameObject.SetActive(true);
        book2_2.gameObject.SetActive(false);
        RightBtn_two_2.gameObject.SetActive(false);
        LeftBtn_two_1.gameObject.SetActive(false);
        LeftBtn_two_2.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_two_2()
    {
        book2_2.gameObject.SetActive(true);
        book2_3.gameObject.SetActive(false);
        LeftBtn_two_2.gameObject.SetActive(false);
        RightBtn_two_2.gameObject.SetActive(true);
        LeftBtn_two_1.gameObject.SetActive(true);
        paper.Play();
    }

    public void Right_btn_nine_1()
    {
        book9_2.gameObject.SetActive(true);
        book9_1.gameObject.SetActive(false);
        RightBtn_nine_1.gameObject.SetActive(false);
        RightBtn_nine_2.gameObject.SetActive(true);
        LeftBtn_nine_1.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_nine_1()
    {
        book9_1.gameObject.SetActive(true);
        book9_2.gameObject.SetActive(false);
        LeftBtn_nine_1.gameObject.SetActive(false);
        RightBtn_nine_1.gameObject.SetActive(true);
        RightBtn_nine_2.gameObject.SetActive(false);
        paper.Play();
    }

    public void Right_btn_nine_2()
    {
        book9_3.gameObject.SetActive(true);
        book9_2.gameObject.SetActive(false);
        RightBtn_nine_2.gameObject.SetActive(false);
        RightBtn_nine_3.gameObject.SetActive(true);
        LeftBtn_nine_2.gameObject.SetActive(false);
        LeftBtn_nine_3.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_nine_2()
    {
        book9_2.gameObject.SetActive(true);
        book9_3.gameObject.SetActive(false);
        RightBtn_nine_2.gameObject.SetActive(true);
        LeftBtn_nine_2.gameObject.SetActive(false);
        RightBtn_nine_3.gameObject.SetActive(false);
        LeftBtn_nine_1.gameObject.SetActive(true);
        paper.Play();
    }

    public void Right_btn_nine_3()
    {
        book9_4.gameObject.SetActive(true);
        book9_3.gameObject.SetActive(false);
        RightBtn_nine_3.gameObject.SetActive(false);
        LeftBtn_nine_3.gameObject.SetActive(true);
        LeftBtn_nine_2.gameObject.SetActive(false);
        paper.Play();
    }

    public void Left_btn_nine_3()
    {
        book9_3.gameObject.SetActive(true);
        book9_4.gameObject.SetActive(false);
        RightBtn_nine_3.gameObject.SetActive(true);
        LeftBtn_nine_2.gameObject.SetActive(true);
        LeftBtn_nine_3.gameObject.SetActive(false);
        paper.Play();
    }
    public void Right_btn_six()
    {
        book6_1.gameObject.SetActive(false);
        book6_2.gameObject.SetActive(true);
        RightBtn_six.gameObject.SetActive(false);
        LeftBtn_six.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_six()
    {
        book6_1.gameObject.SetActive(true);
        book6_2.gameObject.SetActive(false);
        RightBtn_six.gameObject.SetActive(true);
        LeftBtn_six.gameObject.SetActive(false);
        paper.Play();
    }

    public void Right_btn_eight()
    {
        book8_1.gameObject.SetActive(false);
        book8_2.gameObject.SetActive(true);
        RightBtn_eight.gameObject.SetActive(false);
        LeftBtn_eight.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_eight()
    {
        book8_1.gameObject.SetActive(true);
        book8_2.gameObject.SetActive(false);
        RightBtn_eight.gameObject.SetActive(true);
        LeftBtn_eight.gameObject.SetActive(false);
        paper.Play();
    }


    public void Right_btn_ten()
    {
        book10_1.gameObject.SetActive(false);
        book10_2.gameObject.SetActive(true);
        RightBtn_ten.gameObject.SetActive(false);
        LeftBtn_ten.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_ten()
    {
        book10_1.gameObject.SetActive(true);
        book10_2.gameObject.SetActive(false);
        RightBtn_ten.gameObject.SetActive(true);
        LeftBtn_ten.gameObject.SetActive(false);
        paper.Play();
    }

    public void Right_btn_eleven()
    {
        book11_1.gameObject.SetActive(false);
        book11_2.gameObject.SetActive(true);
        RightBtn_eleven.gameObject.SetActive(false);
        LeftBtn_eleven.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_eleven()
    {
        book11_1.gameObject.SetActive(true);
        book11_2.gameObject.SetActive(false);
        RightBtn_eleven.gameObject.SetActive(true);
        LeftBtn_eleven.gameObject.SetActive(false);
        paper.Play();
    }

    public void Right_btn_twelve()
    {
        book12_1.gameObject.SetActive(false);
        book12_2.gameObject.SetActive(true);
        RightBtn_twelve.gameObject.SetActive(false);
        LeftBtn_twelve.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_twelve()
    {
        book12_1.gameObject.SetActive(true);
        book12_2.gameObject.SetActive(false);
        RightBtn_twelve.gameObject.SetActive(true);
        LeftBtn_twelve.gameObject.SetActive(false);
        paper.Play();
    }

    public void Right_btn_thirteen()
    {
        book13_1.gameObject.SetActive(false);
        book13_2.gameObject.SetActive(true);
        RightBtn_thirteen.gameObject.SetActive(false);
        LeftBtn_thirteen.gameObject.SetActive(true);
        paper.Play();
    }

    public void Left_btn_thirteen()
    {
        book13_1.gameObject.SetActive(true);
        book13_2.gameObject.SetActive(false);
        RightBtn_thirteen.gameObject.SetActive(true);
        LeftBtn_thirteen.gameObject.SetActive(false);
        paper.Play();
    }


    public void BookOne()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
    }

    public void BookTwo()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book2_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_two_1.gameObject.SetActive(true);
    }

    public void BookThree()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book3.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
    }

    public void BookFour()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book4.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
    }

    public void BookFive()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book5.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
    }

    public void BookSix()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book6_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_six.gameObject.SetActive(true);
    }

    public void BookSeven()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book7.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
    }

    public void BookEight()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book8_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_eight.gameObject.SetActive(true);
    }

    public void BookNine()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book9_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_nine_1.gameObject.SetActive(true);
    }

    public void BookTen()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book10_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_ten.gameObject.SetActive(true);
    }

    public void BookEleven()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book11_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_eleven.gameObject.SetActive(true);
    }

    public void BookTwelve()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book12_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_twelve.gameObject.SetActive(true);
    }

    public void BookThirteen()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book13_1.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        RightBtn_thirteen.gameObject.SetActive(true);
    }

    public void BookFourteen()
    {
        Inven.gameObject.SetActive(false);
        BoxInven.gameObject.SetActive(false);
        BookInven.gameObject.SetActive(false);
        book14.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
    }
}
