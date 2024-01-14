import socket
import threading
import pickle
from Room import Room

def save_room(room, file_path='room_data.pkl'):
        with open(file_path, 'wb') as file:
            pickle.dump(room, file)
        print(f"Room object saved to {file_path}.")

def load_or_create_room(file_path='room_data.pkl'):
        try:
            with open(file_path, 'rb') as file:
                loaded_room = pickle.load(file)
            print(f"Room object loaded from {file_path}.")
        except FileNotFoundError:
            loaded_room = Room()
            save_room(loaded_room, file_path)
            print(f"Room object created and saved to {file_path}.")
        
        return loaded_room

class Server:
    def __init__(self):
        self.server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.host = '127.0.0.1'
        self.port = 20100
        self.client_count = 0
        self.lock = threading.Lock()


    def start_server(self):
        self.server_socket.bind((self.host, self.port))
        self.server_socket.listen(6)

        print(f"服务器监听中 {self.host}:{self.port}")

        while True:
            client_socket, client_address = self.server_socket.accept()
            with self.lock:
                self.client_count += 1
                print(f"从 {client_address} 连接, 共 {self.client_count} 个连接.")

                client_thread = threading.Thread(target=self.handle_client, args=(client_socket,))
                client_thread.start()

    def handle_client(self, client_socket):
        try:
            data = client_socket.recv(1024)
            getData=data.decode()
            if getData == "OnLoad":
                sendMessage = str(self.client_count-1)
            elif "的客户端请求连接房间1成功!" in getData:
                print(f"从客户端收到信息: {getData}")
                sendMessage = "连接服务器房间1成功!"
            elif "坐" in getData:
                my_room = load_or_create_room()
                user_id=getData[:getData.find("坐")]
                if "1Seated" in getData:
                    if my_room.seats[1]['occupied']==False:
                        my_room.sit_player(1, 'None',user_id)
                        print(f"入座: {getData}")
                        sendMessage = "入座成功!" 
                    else:
                        sendMessage = my_room.seats[1]['id']
                elif "2Seated" in getData:
                    if my_room.seats[2]['occupied']==False:
                        my_room.sit_player(2, 'None',user_id)
                        print(f"入座: {getData}")
                        sendMessage = "入座成功!" 
                    else:
                        sendMessage = my_room.seats[2]['id']
                elif "3Seated" in getData:
                    if my_room.seats[3]['occupied']==False:
                        my_room.sit_player(3, 'None',user_id) 
                        print(f"入座: {getData}")
                        sendMessage = "入座成功!"
                    else:
                        sendMessage = my_room.seats[3]['id'] 
                elif "4Seated" in getData:
                    if my_room.seats[4]['occupied']==False:
                        my_room.sit_player(4, 'None',user_id)  
                        print(f"入座: {getData}")
                        sendMessage = "入座成功!"
                    else:
                        sendMessage = my_room.seats[4]['id']  
                elif "5Seated" in getData:
                    if my_room.seats[5]['occupied']==False:    
                        my_room.sit_player(5, 'None',user_id)  
                        print(f"入座: {getData}")
                        sendMessage = "入座成功!"  
                    else:
                        sendMessage = my_room.seats[5]['id']
                elif "6Seated" in getData:
                    if my_room.seats[6]['occupied']==False:
                        my_room.sit_player(6, 'None',user_id) 
                        print(f"入座: {getData}")
                        sendMessage = "入座成功!"    
                    else:
                        sendMessage = my_room.seats[6]['id'] 
                save_room(my_room, 'room_data.pkl')
                       
            client_socket.send(sendMessage.encode())
            pass
        except Exception as e:
            print(f"处理客户端错误: {e}")
        finally:
            with self.lock:
                self.client_count -= 1
                print(f"客户端断线, 剩余 {self.client_count} 个连接.")
                client_socket.close()

if __name__ == "__main__":
    server = Server()
    server.start_server()
