from locust import HttpUser, task, between, constant_throughput
import random, string
from pyquery import PyQuery

def randomword(length):
   letters = string.ascii_lowercase
   return ''.join(random.choice(letters) for i in range(length))

def randomtitle():
    st = ['cmewifsops','dhxoicrozx','ehaenmqtvz','fdgemffnrx','feaozsgumw','fklrcdhzce','fnahdzoaml','gqdazkbyou','jrgqfkhxbf','knlnqzslkv','mxisaojehu','obwiokcnbf'
          ,'pofdoowkwe','rkvezhvlky','sjcknppvbn','tjfsnvyuhz','tpctqowazd','uiuprfjbzx','vsidwwbolb','wgomobzdip','wtxmhkzjfe','ytruyeaquk']
    return st[random.randint(0,len(st)-1)]

class LocustTest(HttpUser):
    wait_time = constant_throughput(5)
    
    
    
    def on_start(self):
        name = randomword(5)
        email= randomword(12)+'@mail.com'
        role = 'Admin'
        app = 'WEB'
        responce = self.client.post(f"/api/Token/get?name={name}&email={email}&role={role}&app={app}")
        self.client.headers['Authorization'] = 'Bearer '+responce.text
        return super().on_start()
    
    @task(20)
    def api_get_Posts(self):
        self.client.get('/api/Posts')
        
    @task(10)
    def api_post_Posts(self):
        st = randomword(10)
        self.client.post('/api/Posts/',json=
            {
                "title":st
            },
            headers={
                'Authorization' :self.client.headers['Authorization'],
            })
        
    @task(5)
    def api_put_Posts(self):
        sts = randomword(22)
        self.client.put(f'/api/Posts/{randomtitle()}',json=
            {
                "title":sts
            },
            headers={
                'Authorization' :self.client.headers['Authorization'],
            })
        
    @task(1)
    def api_delete_Posts(self):
        self.client.delete(f'/api/Posts/{randomtitle()}',
            headers={
                'Authorization' :self.client.headers['Authorization'],
            })
        
    @task
    def get_site(self):
        response = self.client.get('https://bigcar.sale/search/search_do/?search_string=УРАЛ+43206-0112-61Е5')
        pq = PyQuery(response.text)
        
        txt = '<input title="Поиск" class="form_placeholder search_form_string" autocomplete="off" type="text" size="20" value="" name="search_string">'
        csrf_token = pq('input[name="search_string"]').attr("value")
        print(csrf_token)