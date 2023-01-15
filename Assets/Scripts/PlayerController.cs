using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    private Rigidbody _rb;
    [SerializeField] private Vector3 vectorPoint;
    [SerializeField] private float dead;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int counter = 0;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI tutorialText;
    


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        SetCountText();
        tutorialText.gameObject.SetActive(true);
        Invoke("RemoveText", 5f);

    }
    
    private void FixedUpdate()
    {
        if (transform.position.y < -dead)
        {
            transform.position = vectorPoint;
            Stop();
        }

        Move();
    }
    
    private void Move()
    {
        float moveVertical = Input.GetAxis("Vertical");

        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * (-rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * (rotationSpeed * Time.fixedDeltaTime));
        }
        
        transform.Translate(new Vector3(0f, 0, moveVertical * ballSpeed * Time.fixedDeltaTime),Space.Self);
    }

    void SetCountText()
    {
        countText.text = "Checkpoint: " + counter.ToString();
        
    }
    private void Stop()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            other.gameObject.SetActive(false);
            vectorPoint = transform.position;
            counter+=1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Jump"))
        {
            _rb.AddForce(new Vector3(0,800,0));
        }

        if (other.CompareTag("next"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    void RemoveText()
    {
        tutorialText.gameObject.SetActive(false);
    }

    

    
}
