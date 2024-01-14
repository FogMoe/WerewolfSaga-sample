class Room:
    def __init__(self):
        self.game_started = False
        self.seats = {
            1: {'occupied': False, 'role': None, 'id': None},
            2: {'occupied': False, 'role': None, 'id': None},
            3: {'occupied': False, 'role': None, 'id': None},
            4: {'occupied': False, 'role': None, 'id': None},
            5: {'occupied': False, 'role': None, 'id': None},
            6: {'occupied': False, 'role': None, 'id': None}
        }

    def start_game(self):
        self.game_started = True

    def stop_game(self):
        self.game_started = False

    def sit_player(self, seat_number, role, id):
        if seat_number in self.seats and not self.seats[seat_number]['occupied']:
            self.seats[seat_number]['occupied'] = True
            self.seats[seat_number]['id'] = id
            self.seats[seat_number]['role'] = role
            return True
        else:
            return False
        
    def leave_seat(self, seat_number):
        if seat_number in self.seats and self.seats[seat_number]['occupied']:
            self.seats[seat_number]['occupied'] = False
            self.seats[seat_number]['role'] = None
            self.seats[seat_number]['id'] = None
            return True
        else:
            return False


