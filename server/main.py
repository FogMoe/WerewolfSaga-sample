import socket
import threading

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
