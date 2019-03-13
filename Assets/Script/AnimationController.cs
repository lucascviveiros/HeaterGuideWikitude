using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{

   private Animator anim;
  //  private AnimatorClipInfo[] m_AnimatorClipInfo;
    public GameObject mObj_tampa;
    public GameObject mObj_tampa_base;
    public GameObject mObj_adaptador;
//    public GameObject mObj_pino;
//    public GameObject mObj_seta;
    public Button btn_next;
    public Button btn_back;
    public Text m_texto;
	private AnimatorStateInfo stateInfo;
	private bool active = true;



	void Start () {

        mObj_tampa_base.GetComponent<Renderer>().enabled = true;
        mObj_tampa_base.SetActive(true);

        mObj_adaptador.GetComponent<Renderer>().enabled = true;
        mObj_adaptador.SetActive(true);

        m_texto.text = "Retire a tampa";
        anim = this.GetComponent<Animator>();

        Button btn = btn_next.GetComponent<Button>();
        btn.onClick.AddListener(NextAnimation);

        Button btn2 = btn_back.GetComponent<Button>();
        btn2.onClick.AddListener(BackAnimation);
		Debug.Log("STARTOU");
    }

    private void NextAnimation()
    {
		Debug.Log("NEXT");
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if (stateInfo.IsName("animation_1_tampa"))
		{
			mObj_tampa.SetActive(false);
			mObj_tampa.GetComponent<Renderer>().enabled = false;

			mObj_adaptador.SetActive(true);
			mObj_adaptador.GetComponent<Renderer>().enabled = true;

			mObj_tampa_base.SetActive(true);
			mObj_tampa_base.GetComponent<Renderer>().enabled = true;
			GetComponent<Animator>().Play("animation_2_tampa");
		}

		else if (stateInfo.IsName("animation_2_tampa"))
		{
			mObj_tampa.SetActive(false);
			mObj_tampa.GetComponent<Renderer>().enabled = false;

			mObj_tampa_base.SetActive(true);
			mObj_tampa_base.GetComponent<Renderer>().enabled = true;

			GetComponent<Animator>().Play("animation_3_tampa");

		}
		else if (stateInfo.IsName("animation_2_tampa"))
		{
			mObj_tampa.SetActive(false);
			mObj_tampa.GetComponent<Renderer>().enabled = false;
			GetComponent<Animator>().Play("animation_3_tampa");
		}
		else if (stateInfo.IsName("animation_3_tampa"))
		{
			mObj_tampa_base.SetActive(false);
			mObj_tampa_base.GetComponent<Renderer>().enabled = false;

			mObj_tampa.SetActive(false);
			mObj_tampa.GetComponent<Renderer>().enabled = false;
			active = false;
		}
	}

    private void BackAnimation()
    {
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if (active == false)
		{
			mObj_tampa.SetActive(false);
			mObj_tampa.GetComponent<Renderer>().enabled = false;
			mObj_tampa_base.SetActive(true);
			mObj_tampa_base.GetComponent<Renderer>().enabled = true;
			GetComponent<Animator>().Play("animation_3_tampa");
			active = true;
		}
		else if (stateInfo.IsName("animation_3_tampa"))
		{
			mObj_tampa.SetActive(false);
			mObj_tampa.GetComponent<Renderer>().enabled = false;

			mObj_tampa_base.SetActive(true);
			mObj_tampa_base.GetComponent<Renderer>().enabled = true;

			GetComponent<Animator>().Play("animation_2_tampa");
		}
		else if (stateInfo.IsName("animation_2_tampa"))
		{
			mObj_tampa.SetActive(true);
			mObj_tampa.GetComponent<Renderer>().enabled = true;

			mObj_tampa_base.SetActive(true);
			mObj_tampa_base.GetComponent<Renderer>().enabled = true;
			GetComponent<Animator>().Play("animation_1_tampa");
		}
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    private void Exit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

}
