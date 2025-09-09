using UnityEngine;

/// <summary>
/// Permite que el gameObject patrulle entre dos puntos
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Posición a la que actualmente se dirige el game object
    /// </summary>
    private Transform currentTarget;
    /// <summary>
    /// Velocidad de desplazamiento
    /// </summary>
    private float speed;
    /// <summary>
    /// Representa el transform del punto A
    /// </summary>
    [SerializeField]private Transform pointA;
    /// <summary>
    /// Representa el transform del punto B
    /// </summary>
    [SerializeField]private Transform pointB;
    #endregion

    #region Unity life cycle

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = pointA;
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    #endregion

    #region methods
    /// <summary>
    /// Actualiza la posición del enemigo hacia el objetivoActual
    /// </summary>
    public void Move()
    {
        // Cambio de posición
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime);

        // evaluar ejecutar cambio de objetivo
        if(Vector3.Distance(transform.position,currentTarget.position) < 0.05f)
        {
            ChageTarget();
        }

    }

    /// <summary>
    /// Cambiar la posición objetivo
    /// </summary>
    public void ChageTarget() 
    { 
        if(currentTarget == pointA)
        {
            currentTarget = pointB;
        }
        else
        {
            currentTarget = pointA;
        }
    }

    #endregion

}
