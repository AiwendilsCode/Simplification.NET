import tkinter as tk
import json


class DrawingApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Simple Drawing Application")

        self.canvas = tk.Canvas(root, bg="white", width=1500, height=700)
        self.canvas.pack()

        self.lines = []
        self.current_line = []

        self.canvas.bind("<ButtonPress-1>", self.on_button_press)
        self.canvas.bind("<B1-Motion>", self.on_mouse_drag)
        self.canvas.bind("<ButtonRelease-1>", self.on_button_release)

        self.export_button = tk.Button(
            root, text="Export to JSON", command=self.export_to_json)
        self.export_button.pack()

    def on_button_press(self, event):
        self.current_line = [(event.x, event.y)]

    def on_mouse_drag(self, event):
        self.current_line.append((event.x, event.y))
        self.canvas.create_line(
            self.current_line[-2], self.current_line[-1], fill="black", width=2)

    def on_button_release(self, event):
        self.current_line.append((event.x, event.y))
        self.lines.append(self.current_line)
        self.current_line = []

    def export_to_json(self):
        with open("drawing.json", "w") as f:
            json.dump(self.lines, f)
        print("Coordinates exported to drawing.json")


if __name__ == "__main__":
    root = tk.Tk()
    app = DrawingApp(root)
    root.mainloop()
