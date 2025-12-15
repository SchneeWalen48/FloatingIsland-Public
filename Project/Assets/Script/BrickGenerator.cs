using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 2021.08.03 created by HY
// NEED : Generated Prefab, Room Size, interval
// 벽돌 생성 코드(떨어지는 공간 중심에 빈 오브젝트 생성한 거에 넣어야함), 외부에서 enabled true하면 실행됨

public class BrickGenerator : MonoBehaviour
{
	public int destroyTime = 5; // hy : 파괴 시간(0이면 파괴 안하는거)
	public float interval = 1; // hy : 벽돌이 떨어지는 시간 간격
	public float weight = 10; // hy : 가로 사이즈
	public float height = 10; // hy : 세로 사이즈
	public float yPos = 5; // hy : 떨어지는 높이 지정
	public GameObject prefab; // hy : 벽돌 프리팹

	private GameObject obj;

	// Start is called before the first frame update
	void Start()
    {
		enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		StartCoroutine(Wait(interval)); // hy : interval만큼 쉼
		
		float offsx = Random.Range(-weight, weight);
		float offsz = Random.Range(-height, height);

		Vector3 pos = transform.position + new Vector3(offsx, yPos, offsz);
		GameObject.Instantiate(prefab, pos, Random.rotation).transform.parent = gameObject.transform;

		if(transform.childCount > 3000) // hy : 3000개 넘으면 중지
        {
			enabled = false;
        }
	}

	IEnumerator Wait(float interval)
    {
		yield return new WaitForSeconds(interval);

		if (destroyTime > 0)
		{
			yield return new WaitForSeconds(destroyTime);
			Destroy(transform.GetChild(0).gameObject);
		}
    }
}
