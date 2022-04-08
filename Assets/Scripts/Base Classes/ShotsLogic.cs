using UnityEngine;

public class ShotsLogic : MonoBehaviour
{
    [SerializeField] private ProjectData _data;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _count = 10;

    private Transform _pose;
    private GameObject[] _pool;
    private Camera _cam;
    private int _id = 0;
    private bool _shot = false;

    private void Start()
    {
        _cam = Camera.main;
        _parent = transform;
        _pose = GameObject.FindGameObjectWithTag("barrel").transform;
        _pool = new GameObject[_count];

        for(int i = 0; i < _count; i++)
        {
            _pool[i] = Instantiate(_data._bullet, transform.position, transform.rotation, _parent);
            _pool[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !_data._walk && !_shot)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out RaycastHit hit);

            GameObject bullet = _parent.GetChild(_id).gameObject;
            bullet.SetActive(true);
            bullet.transform.position = _pose.position;
            bullet.transform.LookAt(hit.point);

            Rigidbody _bul = bullet.GetComponent<Rigidbody>();
            _bul.velocity = new Vector3(0, 0, 0);
            _bul.AddForce(bullet.transform.forward*_data._bulletImpulse, ForceMode.Impulse);

            _id++;
            if (_id > _count - 1) _id = 0; 
            _shot = true;
        }
        else if(_shot) _shot = false; 
    }
}
