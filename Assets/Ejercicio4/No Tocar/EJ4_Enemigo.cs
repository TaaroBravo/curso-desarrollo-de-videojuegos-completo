using UnityEngine;

public class EJ4_Enemigo : MonoBehaviour
{
    public Transform limitLeft;
    public Transform limitRight;
    public bool movingLeft;
    
    private void Update()
    {
        if (movingLeft)
        {
            var wantedPosition = transform.position;
            wantedPosition.x = limitLeft.position.x;
            transform.position += (wantedPosition - transform.position).normalized * (Time.deltaTime * 0.5f);
            if (Vector2.Distance(transform.position, wantedPosition) < 1)
                movingLeft = false;
        }
        else
        {
            var wantedPosition = transform.position;
            wantedPosition.x = limitRight.position.x;
            transform.position += (wantedPosition - transform.position).normalized * (Time.deltaTime * 0.5f);
            if (Vector2.Distance(transform.position, wantedPosition) < 1)
                movingLeft = true;
        }
    }
}