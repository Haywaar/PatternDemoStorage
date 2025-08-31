  
  
  
  class PlayerV1:
        def __init__(self, health: float, max_health: float):
    self._health = health 
    self._max_health = max_health

    @property
        def health(self) -> float:
    return self._health

    def set_health(self, health: float) -> None:
    self._health = health