import asyncio
from bleak import BleakScanner

async def scan_devices():
    print("Research of any bluetooth device...")
    devices = await BleakScanner.discover()

    for d in devices:
        # Trying to find Movesense sensor
        if d.name and "Movesense" in d.name:
            print(f"✅ We got it ! Name: {d.name} | Address: {d.address}")

# Starting async function
asyncio.run(scan_devices())