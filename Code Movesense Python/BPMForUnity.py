import asyncio
import socket
from bleak import BleakClient

### MAC address from the BPM sensor
MAC_ADDRESS = "0C:8C:DC:33:1B:0D"

# UUID world standard to read BPM
HR_CHARACTERISTIC_UUID = "00002a37-0000-1000-8000-00805f9b34fb"

# Configuration UDP for the socket (for unity)
UDP_IP = "127.0.0.1" # Computer local address
UDP_PORT = 5050      # Port ( need to be the same which unity is listening)
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)


### Treatement of the Data
def hr_notification_handler(sender, data):

    # The first octet (data[1]) contain BPM
    bpm = data[1]
    print(f"Heart Beat : {bpm} BPM")

    # Converting the number into string to send it at unity
    sock.sendto(str(bpm).encode('utf-8'), (UDP_IP, UDP_PORT))


# Bluetooth link
async def connect_and_listen():
    print(f"Trying to connect at  {MAC_ADDRESS}...")

    async with BleakClient(MAC_ADDRESS) as client:
        print("✅ Connected !")

        await client.start_notify(HR_CHARACTERISTIC_UUID, hr_notification_handler)

        print("Sending datas to Unity with the port", UDP_PORT)
        print("Press Ctrl+C to leave.")

        # Infinite while to keep the conection open
        while True:
            await asyncio.sleep(1)

# Starting of the programm
if __name__ == "__main__":
    try:
        asyncio.run(connect_and_listen())
    except KeyboardInterrupt:
        print("\nProgramm ended.")