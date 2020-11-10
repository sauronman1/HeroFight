using UnityEngine;
using UnityEngine.UI;

namespace FutureGames.JRPG_Rocket
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private GameObject[] products = new GameObject[0];

        public void ShowDamage(float damage, Vector3 playerPosition)
        {
            Vector2 randomPos = new Vector2(transform.position.x, Random.Range(transform.position.y +50, transform.position.y));
            GameObject damageText = Instantiate(products[0],randomPos, transform.rotation);
            damageText.transform.parent = GameObject.Find("Canvas").gameObject.transform;
            damageText.GetComponent<Text>().text = "Damage " + damage.ToString();
            Destroy(damageText, 3);
        }
    }
}
