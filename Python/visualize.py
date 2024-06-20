import tkinter as tk
import json


class LineVisualizer:
    def __init__(self, root, json_file):
        self.root = root
        self.root.title("Line Visualizer")

        self.canvas = tk.Canvas(root, bg="white", width=1500, height=800)
        self.canvas.pack()

        self.lines = self.load_from_json(json_file)
        self.draw_lines()

    def load_from_json(self, json_file):
        with open(json_file, "r") as f:
            lines = json.load(f)
        return lines

    def draw_lines(self):
        for line in self.lines:
            for i in range(len(line) - 1):
                self.canvas.create_line(
                    line[i], line[i+1], fill="black", width=2)


if __name__ == "__main__":
    root = tk.Tk()
    json_file = "visvalingamMemOpt.json"  # Replace with your JSON file path
    app = LineVisualizer(root, json_file)
    root.mainloop()
