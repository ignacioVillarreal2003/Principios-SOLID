# Principio SRP

SRP: El principio de una sola responsabilidad

## ¿Qué es SRP?
> Una entidad de software debe tener una y solo una razón para cambiar.

## Ejemplo
~~~
public function routes(array $attributes = null)
    {
        if ($this->app instanceof CachesRoutes && $this->app->routesAreCached()) {
            return;
        }

        $attributes = $attributes ?: ['middleware' => ['web']];

        $this->app['router']->group($attributes, function ($router) {
            $router->match(
                ['get', 'post'], '/broadcasting/auth',
                '\\'.BroadcastController::class.'@authenticate'
            )->withoutMiddleware([\Illuminate\Foundation\Http\Middleware\VerifyCsrfToken::class]);
        });
    }
~~~
