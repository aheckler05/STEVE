using UnityEngine;

public class pufferfishScript : MonoBehaviour
{
    public Transform target;
    public Transform guyPos;
    public GameObject spines;
    public GameObject guy;
    public float speed = 2f;
    public float radius = 1f;
    public float angle = 0f;
    float x, y, z;
    int num = 6;

    public void shootSpines(){
        for (int i = 0; i < num; i++){
		
            var point = new Vector3 (guyPos.position.x, guyPos.position.y, guyPos.position.z);
            /* Distance around the circle */  
            var radians = 2 * Mathf.PI / num * i;
            
            /* Get the vector direction */ 
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians); 
            
            var spawnDir = new Vector3 (horizontal, vertical, 0);
            
            /* Get the spawn position */ 
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point
            
            /* Now spawn */
            var enemy = Instantiate(spines, spawnPos, Quaternion.identity) as GameObject;

            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearDamping = 2f;        
                rb.angularDamping = 1f; 
                rb.gravityScale = 0; 
                rb.linearVelocity = spawnDir * 2f;
            }   
        }
    }

    void OnMouseDown()
    {
        speed = 0f;
        guy.SetActive(false);
    }

    private int i = 0;
    // Update is called once per frame
    void Update()
    {
        x = target.position.x + Mathf.Cos(angle) * radius;
        y = target.position.y + Mathf.Sin(angle) * radius;
        z = target.position.z;

        transform.position = new Vector3(x, y, z);

        angle += speed * Time.deltaTime;

        if(i%500 == 1){
            shootSpines();
        }
        i++;
    }
}
